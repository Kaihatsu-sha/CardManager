using Kaihatsu.CardManager.DAL.Entities;

namespace Kaihatsu.CardManager.Identity.Interfaces;

public interface IAuthorizationManager
{
    SessionInfo SignIn(string login, string password);
    void SignOut(Guid session);
    SessionInfo IsSign(string accessToken);
    SessionInfo RefreshToken(string refreshToken);
}
