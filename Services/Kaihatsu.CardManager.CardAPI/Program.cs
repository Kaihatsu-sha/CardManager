using Kaihatsu.CardManager.Core;
using Kaihatsu.CardManager.Core.Interfaces;
using Kaihatsu.CardManager.DAL;
using Kaihatsu.CardManager.DAL.Interfaces;
using Kaihatsu.CardManager.DAL.Repository;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All | HttpLoggingFields.RequestQuery;
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
    logging.RequestHeaders.Add("Authorization");
    logging.RequestHeaders.Add("X-Real-IP");
    logging.RequestHeaders.Add("X-Forwarded-For");
});

builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();

}).UseNLog(new NLogAspNetCoreOptions() { RemoveLoggerFactoryFilter = true });

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
app.UseHttpLogging();

app.MapControllers();

app.Run();
