using Kaihatsu.CardManager.Core;

namespace Kaihatsu.CardManager.DAL.Entities;

public class Account : BaseEntity
{
    public string EMail { get; set; }

    public string PasswordSalt { get; set; }

    public string PasswordHash { get; set; }

    public bool IsLocked { get; set; }

    public string LastName { get; set; }

    public string FirstName { get; set; }    

    public string Patronymic { get; set; }

    public virtual ICollection<AccountSession> Sessions { get; set; } = new HashSet<AccountSession>();
}
