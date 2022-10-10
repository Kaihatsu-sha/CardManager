namespace Kaihatsu.CardManager.Identity.Interfaces;

public interface IAccountManager
{
    void Create(string login, string password);
    void Delete(Guid id);
}
