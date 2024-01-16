using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDb_Basic_Api.Models;
using MongoDb_Basic_Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection(nameof(MongoDBSettings)));
builder.Services.AddSingleton<IMongoDBSettings>(sp => sp.GetRequiredService<IOptions<MongoDBSettings>>().Value);
builder.Services.AddSingleton<UserMusicFavoritesService>();
//builder.Services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
