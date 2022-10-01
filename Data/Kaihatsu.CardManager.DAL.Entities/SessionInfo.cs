using Kaihatsu.CardManager.Core;

namespace Kaihatsu.CardManager.DAL.Entities;

public class SessionInfo 
{
    public Guid Id { get; set; }
    public string AccessToken { get; set; }

    public string RefreshToken { get; set; }
}
