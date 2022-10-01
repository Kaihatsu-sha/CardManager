using Kaihatsu.CardManager.Core;

namespace Kaihatsu.CardManager.DAL.Entities;

public class AccountSession: BaseEntity
{
    public string AccessToken { get; set; }

    public string RefreshToken { get; set; }

    public DateTime Created { get; set; }

    public DateTime LastRequest { get; set; }

    public bool IsClosed { get; set; } //TODO: Избыточное поле?

    public DateTime? Closed { get; set; }

    public virtual Account Account { get; set; }

    public Guid AccountId { get; set; }

}
