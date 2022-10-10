using Kaihatsu.CardManager.DAL;
using Kaihatsu.CardManager.DAL.Entities;
using Kaihatsu.CardManager.Identity.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Kaihatsu.CardManager.Identity;

public class AuthorizationManager : IAuthorizationManager
{
    public const string SecretKey = "kYp3s6v9y/B?E(H+";
    private readonly IIdentityManager _identityManager;
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly Dictionary<string, SessionInfo> _sessions = new Dictionary<string, SessionInfo>();//FIX: Конкурентая коллекция?

    public AuthorizationManager(IServiceScopeFactory serviceScopeFactory)
    {
        _identityManager = new IdentityManager(serviceScopeFactory);
        _serviceScopeFactory = serviceScopeFactory;
    }    

    public SessionInfo SignIn(string login, string password)
    {
        Account? account = _identityManager.SearchAccount(login);//Идентификация
        if (account is null)
            throw new Exception();

        if (account.IsLocked)
            throw new Exception();

        if (!PasswordUtils.VerifyPassword(password, account.PasswordSalt, account.PasswordHash))//Аутентификация
            throw new Exception();

        AccountSession session = new AccountSession
        {
            AccessToken = CreateAccessToken(account),
            RefreshToken = CreateRefreshToken(account),
            Created = DateTime.UtcNow,
            LastRequest = DateTime.UtcNow,
            AccountId = account.Id
        };

        //Запись в БД
        using IServiceScope scope = _serviceScopeFactory.CreateScope();
        CardManagerDbContext context = scope.ServiceProvider.GetRequiredService<CardManagerDbContext>();
        context.Sessions.Add(session);
        context.SaveChanges();

        SessionInfo sessionInfo = new SessionInfo
        {
            Id = session.Id,
            AccessToken = session.AccessToken,
            RefreshToken = session.RefreshToken
        };

        lock (_sessions)
        {
            _sessions[sessionInfo.AccessToken] = sessionInfo;
        }

        return sessionInfo;
    }


    public SessionInfo IsSign(string accessToken)
    {
        SessionInfo sessionInfo;
        
        lock (_sessions)
        {
            _sessions.TryGetValue(accessToken, out sessionInfo);
        }

        if (sessionInfo is null)
            throw new Exception();

        return sessionInfo;
    }

    public SessionInfo RefreshToken(string refreshToken)
    {
        throw new NotImplementedException();
    }

    public void SignOut(Guid session)
    {
        throw new NotImplementedException();
    }

    private string CreateAccessToken(Account account) => CreateToken(account, DateTime.UtcNow.AddMinutes(15));

    private string CreateRefreshToken(Account account) => CreateToken(account, DateTime.UtcNow.AddHours(6));

    private string CreateToken(Account account, DateTime expires)
    {
        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        byte[] key = Encoding.ASCII.GetBytes(SecretKey);

        SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
                new Claim[]{
                        new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
                        new Claim(ClaimTypes.Name, account.Login),
                }),
            Expires = expires,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
