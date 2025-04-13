using Catalog.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCatalogServices();

builder.Services.AddMarten(options =>
{
    options.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapCarter();

app.AddApplicationBuilder();

app.Run();
