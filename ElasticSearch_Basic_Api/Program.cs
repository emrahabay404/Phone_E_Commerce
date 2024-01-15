using ElasticSearch_Basic_Api.Models;
using ElasticSearch_Basic_Api.Services;
using Nest;

var builder = WebApplication.CreateBuilder(args);

var settings = new ConnectionSettings(new Uri("http://localhost:9200/")).DefaultIndex("es_crud_api");
var client = new ElasticClient(settings);
builder.Services.AddSingleton(client);
builder.Services.AddScoped<IElasticSearchService<Product>, ElastichSearchService<Product>>();

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
