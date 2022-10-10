using Kaihatsu.CardManager.DAL.Entities;

namespace Kaihatsu.CardManager.Identity.Interfaces;

internal interface IIdentityManager
{
    Account? SearchAccount(string login);
}
