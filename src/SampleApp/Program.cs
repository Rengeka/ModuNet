using ModuNet.AspNet.Extentions;
using SampleModule.Application;
using SampleModule.Bootstrap;

var builder = WebApplication.CreateBuilder(args);

builder.AddModule<ISampleModule, SampleModule.Bootstrap.SampleModule>(SampleModuleStartup.ConfigureServices);

var services = builder.Services;

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseSampleModule();

await app.RunAsync();