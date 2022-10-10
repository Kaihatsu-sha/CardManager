using Kaihatsu.CardManager.DAL;
using Kaihatsu.CardManager.DAL.Entities;
using Kaihatsu.CardManager.Identity.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Kaihatsu.CardManager.Identity;

internal class IdentityManager : IIdentityManager
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public IdentityManager(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public Account? SearchAccount(string login)
    {
        using (IServiceScope scope = _serviceScopeFactory.CreateScope())
        {
            CardManagerDbContext context = scope.ServiceProvider.GetRequiredService<CardManagerDbContext>();
            return context.Accounts.FirstOrDefault(e => e.Login.Equals(login.ToLower()));
        }
    }
}
