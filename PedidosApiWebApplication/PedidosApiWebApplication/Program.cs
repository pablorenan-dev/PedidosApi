using Microsoft.EntityFrameworkCore;
using PedidosApiWebApplication;
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

using (var e = app.Services.CreateScope())
{
    // obtendo todas as tabelas do banco
    var banco = e.ServiceProvider.GetRequiredService<PedidosContext>();

    banco.Database.Migrate();
    // Semear os dados inicias
    InicializarDados.Semear(banco);
}

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
