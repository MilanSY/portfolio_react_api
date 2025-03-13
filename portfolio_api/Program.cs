using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using portfolio_api.Services;
using portfolio_api.Storage;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<ITechnoService, TechnoService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IDocService, DocService>();

builder.Services.AddScoped<ITechnoStorage, TechnoStorage>();
builder.Services.AddScoped<IProjectStorage, ProjectStorage>();
builder.Services.AddScoped<IDocStorage, DocStorage>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:5173")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

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

app.UseCors("AllowSpecificOrigin");

app.MapControllers();

app.Run();