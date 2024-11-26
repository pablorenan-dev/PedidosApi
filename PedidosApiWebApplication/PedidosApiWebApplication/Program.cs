using Microsoft.EntityFrameworkCore;
using PedidosApiWebApplication.BancoDeDados;

var builder = WebApplication.CreateBuilder(args);

//obtem o endereco do banco de dados
var connectionString = builder.Configuration.GetConnectionString("Conexao");

builder.Services.AddDbContext<PedidosContext>(config =>
{
    config.UseSqlite(connectionString);
});

// Add services to the container.

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
