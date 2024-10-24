using Microsoft.EntityFrameworkCore;
using WebAPIREST.Context;
using WebAPIREST.Repositories.Interface;
using WebAPIREST.Repositories.Repository;

var builder = WebApplication.CreateBuilder(args);
// Aula de .NET do dia 15/10/2024

// Add services to the container.

builder.Services.AddDbContext<AppContextDb>(options => options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IEnderecoRepository, EnderecoRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
