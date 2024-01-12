using JwtTokenAuthentication;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot(builder.Configuration);

builder.Services.AddJwtAuthentication();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

await app.UseOcelot();
app.Run();
