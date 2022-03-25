using EscolaDeIdiomas.WebApi.Contexts;
using EscolaDeIdiomas.WebApi.Interfaces;
using EscolaDeIdiomas.WebApi.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EscolaDeIdiomasContext>(o => o.UseSqlServer("Data Source=LAPTOP-DFNK1JF6\\MATEUSSQLSERVER; initial catalog=EscolaDeIdiomas; integrated Security=True;"));

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
