using ModuNetWebApp.Weather.Application;
using ModuNetWebApp.Weather.Bootstrap;
using ModuNet.AspNet.Core.Extentions;

var builder = WebApplication.CreateBuilder(args);

builder.AddModule<IWeatherModule, WeatherModule>(WeatherModuleStartup.ConfigureServices);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseModule(UseWeatherModule.UseServices);

app.UseHttpsRedirection();

app.Run();