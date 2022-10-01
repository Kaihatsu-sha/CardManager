using Kaihatsu.CardManager.Core;

namespace Kaihatsu.CardManager.DAL.Entities;

public class Account : BaseEntity
{
    public string Login { get; set; }
    public string PasswordHash { get; set; }
    public string PasswordSalt { get; set; }
    public bool IsLocked { get; set; }
    public virtual ICollection<AccountSession> Sessions { get; set; } = new HashSet<AccountSession>();
}
