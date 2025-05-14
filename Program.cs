using System.Reflection;
using BookStoreApi.Endpoints;
using BookStoreApi.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.AddApplicationServices(); // This method registers the necessary services for the API. It is an extension method we created earlier to add services to the dependency injection container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Mimal API",
        Version = "v1",
        Description = "Showing how you can build minimal " +
        "api with .net"
    });


    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();//for redirecting http request
app.UseExceptionHandler();
app.MapGroup("/api/v1/")
    .WithTags("Book endpoints")
    .MapBookEndpoints();

app.Run();
