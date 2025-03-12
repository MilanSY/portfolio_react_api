using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using portfolio_api.Services;
using portfolio_api.Storage;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSingleton<ITechnoService, TechnoService>();
builder.Services.AddSingleton<IProjectService, ProjectService>();
builder.Services.AddSingleton<IDocService, DocService>();

builder.Services.AddSingleton<ITechnoStorage, TechnoStorage>();
builder.Services.AddSingleton<IProjectStorage, ProjectStorage>();
builder.Services.AddSingleton<IDocStorage, DocStorage>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Portfolio API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Portfolio API v1"));
}

app.UseHttpsRedirection();

// Mapping des endpoints
app.MapControllers();

app.Run();