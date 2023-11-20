using Autofac;
using Autofac.Extensions.DependencyInjection;
using DataAccess.Concrete.EntityFramework;
using E_Commerce_Business.DependencyResolvers.Autofac;
using E_Commerce_Business.Mapping;
using E_Commerce_Core.Utilities.Security.Encryption;
using E_Commerce_Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;
using Swashbuckle.AspNetCore.Filters;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


//Serilog için
builder.Host.UseSerilog((context, configuration) =>
configuration.ReadFrom.Configuration(context.Configuration));
//Serilog için


////REDÝS ConnectionMultiplexer KULLANIMI ÝÇÝN
IConfiguration configuration = builder.Configuration;
var multiplexer = ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis"));
builder.Services.AddSingleton<IConnectionMultiplexer>(multiplexer);
////REDÝS ConnectionMultiplexer KULLANIMI ÝÇÝN


//dapper için 
//builder.Services.AddTransient<DapperDBContext>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();


////REDÝS KULLANIMI ÝÇÝN
//builder.Services.AddDistributedRedisCache(options =>
//{
//   options.Configuration = "127.0.0.1:6379";
//});
//builder.Services.AddSingleton<IConnectionMultiplexer>(x => ConnectionMultiplexer.Connect(
//   new ConfigurationOptions
//   {
//      EndPoints = { $"{builder.Configuration.GetValue<string>("Redis:Host")}:{builder.Configuration.GetValue<int>("Redis:Port")}" }
//   }));
//builder.Services.AddScoped<IRedisService, RedisService>();
////REDÝS KULLANIMI ÝÇÝN


builder.Services.AddSwaggerGen(options =>
{
   options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
   {
      Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
      In = ParameterLocation.Header,
      Name = "Authorization",
      Type = SecuritySchemeType.ApiKey
   });
   options.OperationFilter<SecurityRequirementsOperationFilter>();
});


//API de Standart DbContext i kullanabilmek için
builder.Services.AddTransient<E_Commerce_DbContext>();


//builder.Services.AddDbContext<E_Commerce_DbContext>(option =>
//{
//   option.UseSqlServer(builder.Configuration.GetConnectionString("SqlConn"));
//});


//HTTP CONTEXT ACCESOR ÝÇÝN
builder.Services.AddHttpContextAccessor();
//HTTP CONTEXT ACCESOR ÝÇÝN

//automapper için
builder.Services.AddAutoMapper(typeof(GeneralMapping).Assembly);
//automapper için

//AUTOFAC kullanýmý için 
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutoFacBusiness()));
//////

builder.Services.AddCors(options => options.AddPolicy(name: "E_Commerce_Origins",
    policy =>
    {
       policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
    }));

//builder.Services.AddLocalization();

///JWT OLUÞTURMA ÝÇÝN
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

builder.Services.AddAuthorization(options =>
{
   options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
       .RequireAuthenticatedUser()
       .Build();
});
///JWT OLUÞTURMA ÝÇÝN

var app = builder.Build();


///CACHE ÝÇÝN
//var cacheManager = app.Services.GetRequiredService<ICacheManager>();
//cacheManager.Add("nbf", DateTimeOffset.Now.ToUnixTimeSeconds(), 600);
///CACHE ÝÇÝN


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI();
}



//Serilog
app.UseSerilogRequestLogging();
//Serilog

//app.UseRequestLocalization(new RequestLocalizationOptions
//{
//   DefaultRequestCulture = new RequestCulture(new CultureInfo("tr-TR"))
//});

app.UseCors("E_Commerce_Origins");

//app.UseCors(options =>
//options.WithOrigins("https://localhost:7175","*")
//.AllowAnyMethod()
//.AllowAnyOrigin()
//.AllowAnyHeader());

//builder.Services.AddCors();


//app.ConfigureCustomExceptionMiddleware();
app.UseAuthentication();
//app.UseLogoutHandler();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
