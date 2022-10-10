using Kaihatsu.CardManager.DAL;
using Kaihatsu.CardManager.DAL.Entities;
using Kaihatsu.CardManager.Identity.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Kaihatsu.CardManager.Identity;

public class AccountManager : IAccountManager
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly IIdentityManager _identityManager;

    public AccountManager(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
        _identityManager = new IdentityManager(serviceScopeFactory); ;
    }

    public void Create(string login, string password)
    {
        if (_identityManager.SearchAccount(login) is not null)
            throw new OperationCanceledException();//FIX: Аккаунт уже существует

        //Получение хеша и соли
        var createdHash = PasswordUtils.CreatePasswordHash(password);

        //Создание аккаунта
        Account newAccount = new Account
        {
            Login = login.ToLower(),
            PasswordHash = createdHash.passwordHash,
            PasswordSalt = createdHash.passwordSalt
        };

        using (IServiceScope scope = _serviceScopeFactory.CreateScope())
        {
            CardManagerDbContext context = scope.ServiceProvider.GetRequiredService<CardManagerDbContext>();
            context.Accounts.Add(newAccount);
            context.SaveChanges();
        }
    }

    public void Delete(Guid id)
    {
        using (IServiceScope scope = _serviceScopeFactory.CreateScope())
        {
            CardManagerDbContext context = scope.ServiceProvider.GetRequiredService<CardManagerDbContext>();
            Account? account = context.Accounts.FirstOrDefault(e => e.Id.Equals(id));
            if (account is null)
                throw new Exception();

            account.IsLocked = true;

            context.Update(account);
            context.SaveChanges();
        }
    }
}
