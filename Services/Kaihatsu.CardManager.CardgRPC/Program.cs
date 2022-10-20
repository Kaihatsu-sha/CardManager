using Kaihatsu.CardManager.DAL.Interfaces;
using Kaihatsu.CardManager.DAL.Repository;
using Kaihatsu.CardManager.DAL;
using System.Net;
using Kaihatsu.CardManager.AutoMapper;
using Microsoft.EntityFrameworkCore;
using Kaihatsu.CardManager.CardgRPC.Services;

var builder = WebApplication.CreateBuilder(args);

//gRPC

builder.WebHost.ConfigureKestrel(options =>
{
    options.Listen(IPAddress.Any, 5001, listenOptions =>
    {
        listenOptions.Protocols = Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http2;
    });
});

builder.Services.AddGrpc();

builder.Services.AddDbContext<CardManagerDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"), p => p.MigrationsAssembly("Kaihatsu.CardManager.DAL.MSSQL"))
);

builder.Services.AddCardMapper();
builder.Services.AddScoped<ICardRepositoryAsync, CardRepositoryAsync>();
builder.Services.AddScoped<IClientRepositoryAsync, ClientRepositoryAsync>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGrpcService<CardSer>();
    endpoints.MapGrpcService<ClientSer>();

});

app.MapControllers();

app.Run();
