using DotNetCoreMicroservicesTemplate.Data;
using DotNetCoreMicroservicesTemplate.Entities;
using DotNetCoreMicroservicesTemplate.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<IDatabaseContext, DatabaseContext>();
builder.Services.AddScoped<ISampleQuizRepository, SampleQuizRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable middleware to serve generated Swagger as a JSON endpoint.
app.UseSwagger(c =>
{
    c.RouteTemplate = "swagger/{documentName}/swagger.json";
    c.SerializeAsV2 = true;
});

// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
// specifying the Swagger JSON endpoint.
//Add Swagger Version
app.UseSwaggerUI(c =>
{
    c.RoutePrefix = "swagger";
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");

    // custom CSS
    c.InjectStylesheet("/swagger-ui/custom.css");
});
app.UseHttpsRedirection();
app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

app.UseAuthorization();

app.MapControllers();

app.Run();
