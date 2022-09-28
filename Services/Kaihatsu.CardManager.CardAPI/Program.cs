using Kaihatsu.CardManager.Core;
using Kaihatsu.CardManager.Core.Interfaces;
using Kaihatsu.CardManager.DAL;
using Kaihatsu.CardManager.DAL.Interfaces;
using Kaihatsu.CardManager.DAL.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<CardManagerDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"), p => p.MigrationsAssembly("Kaihatsu.CardManager.DAL.MSSQL"))
);

//builder.Services.AddScoped(typeof(IRepositoryAsync<,>), typeof(CardRepository<>));
builder.Services.AddScoped<ICardRepositoryAsync, CardRepositoryAsync>();
builder.Services.AddScoped<IClientRepositoryAsync, ClientRepositoryAsync>();


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

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
