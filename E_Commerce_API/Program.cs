using Autofac;
using Autofac.Extensions.DependencyInjection;
using DataAccess.Concrete.EntityFramework;
using E_Commerce_Business.DependencyResolvers.Autofac;
using E_Commerce_Business.Mapping;
using E_Commerce_Core.Utilities.Security.Encryption;
using E_Commerce_Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Swashbuckle.AspNetCore.Filters;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Serilog konfigürasyonu
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

// Autofac entegrasyonu
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
    containerBuilder.RegisterModule(new AutoFacBusiness()));

// Redis baðlantýsý (aktif deðil, kullanýlacaksa açýlabilir)
// var multiplexer = ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("Redis"));
// builder.Services.AddSingleton<IConnectionMultiplexer>(multiplexer);

// Servisler için ayarlar
builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();

// Swagger konfigürasyonu
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Authorization header using the Bearer scheme (\"{token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

// Dapper ve DbContext kullanýmý
builder.Services.AddSingleton<E_Commerce_DbContext>();

// HttpContextAccessor
builder.Services.AddHttpContextAccessor();

// AutoMapper konfigürasyonu
builder.Services.AddAutoMapper(typeof(GeneralMapping).Assembly);

// CORS ayarlarý
builder.Services.AddCors(options => options.AddPolicy(name: "E_Commerce_Origins",
    policy =>
    {
        policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
    }));

// Localization ayarlarý
builder.Services.AddLocalization();

// JWT Token oluþturma ayarlarý
var tokenOptions = builder.Configuration.GetRequiredSection("TokenOptions").Get<TokenOptions>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });

// Tüm uygulama için yetkilendirme (Authorize) zorunlu olacak þekilde ayarlama
builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser()
        .Build();
});

var app = builder.Build();

// Geliþtirme ortamý için Swagger ve UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Serilog ile istek loglama
app.UseSerilogRequestLogging();

// HTTPS yönlendirmesi
app.UseHttpsRedirection();

// Localization için dil ayarlarý
var supportedCultures = new[] { new CultureInfo("tr-TR"), new CultureInfo("en-US") };
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("tr-TR"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});

// CORS politikasýný etkinleþtirme
app.UseCors("E_Commerce_Origins");

// Statik dosya ayarlarý
app.UseStaticFiles();

// Authentication ve Authorization middleware'leri
app.UseAuthentication();
app.UseAuthorization();

// Controller rotalarý
app.MapControllers();

// Uygulamayý çalýþtýr
app.Run();
