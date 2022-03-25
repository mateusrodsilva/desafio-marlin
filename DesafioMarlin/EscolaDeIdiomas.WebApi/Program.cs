using EscolaDeIdiomas.WebApi.Contexts;
using EscolaDeIdiomas.WebApi.Interfaces;
using EscolaDeIdiomas.WebApi.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "EscolaDeIdiomas.WebApi", Version = "v1" });

    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddDbContext<EscolaDeIdiomasContext>(o => o.UseSqlServer("Data Source=LAPTOP-69MCT9P6; initial catalog=EscolaDeIdiomas; user Id=mateus; pwd=123456"));

//Injeções de dependencia
builder.Services.AddTransient<IAlunoRepository, AlunoRepository>();
builder.Services.AddTransient<ITurmaRepository, TurmaRepository>();
builder.Services.AddTransient<IMatriculaRepository, MatriculaRepository>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
