
namespace Kaihatsu.CardManager.Authorization.Interfaces;

public interface IAuthorization
{
    bool Logon();
    bool Logout();
    bool VarifiAuthorization();
}
