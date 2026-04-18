using ModuNet.AspNet.Extentions;
using ModuNetWebApp.Weather.Application;
using ModuNetWebApp.Weather.Bootstrap;

var builder = WebApplication.CreateBuilder(args);

builder.AddModule<IWeatherModule, WeatherModule>(WeatherModuleStartup.ConfigureServices);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseWeatherModule();

app.UseHttpsRedirection();

app.Run();