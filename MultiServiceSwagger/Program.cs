using Microsoft.OpenApi.Models;
using MultiServiceSwagger.Extension;
using MultiServiceSwagger.Models;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();
var settings = builder.Configuration.GetSection("Swagger").Get<SwaggerSettings>();
var baseUrl = builder.Configuration.GetSection("BASE_URL").Value;

var temp = app.Environment;
app.UseSwaggerUI(settings.SwaggerUiConfig(baseUrl));

app.MapGet("/", () => "Hello World!");

app.Run();