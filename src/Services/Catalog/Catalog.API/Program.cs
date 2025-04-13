using Catalog.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCatalogServices(builder.Configuration);

var app = builder.Build();

app.MapCarter();

app.AddApplicationBuilder();

app.Run();
