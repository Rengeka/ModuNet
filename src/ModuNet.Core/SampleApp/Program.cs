using SampleModule.Bootstrap;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddSampleModule(builder.Configuration);

var app = builder.Build();

//app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseSampleModule();

await app.RunAsync();