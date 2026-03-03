using AgendaApp.Domain.Interfaces;
using AgendaApp.Domain.Interfaces.Repositories;
using AgendaApp.Domain.Services;
using AgendaApp.Infra.Data.Repositories;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Injeções de dependência
builder.Services.AddTransient<ITarefaService, TarefaService>();
builder.Services.AddTransient<ITarefaRepository, TarefaRepository>();

var app = builder.Build();

app.MapOpenApi();

//Swagger
app.UseSwagger();
app.UseSwaggerUI();

//Scalar
app.MapScalarApiReference(s => s.WithTheme(ScalarTheme.BluePlanet));

app.UseAuthorization();

app.MapControllers();

app.Run();
