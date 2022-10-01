
using Kaihatsu.CardManager.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kaihatsu.CardManager.DAL;

public class CardManagerDbContext : DbContext
{
    public DbSet<Card> Cards { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountSession> Sessions { get; set; }

    public CardManagerDbContext(DbContextOptions<CardManagerDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
