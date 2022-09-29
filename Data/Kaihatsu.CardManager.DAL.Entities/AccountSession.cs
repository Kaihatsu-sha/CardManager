using Kaihatsu.CardManager.Core;

namespace Kaihatsu.CardManager.DAL.Entities;

public class AccountSession: BaseEntity
{
    public string SessionToken { get; set; } 

    public DateTime TimeCreated { get; set; }
    
    public DateTime TimeLastRequest { get; set; }

    public bool IsClosed { get; set; }
    
    public DateTime? TimeClosed { get; set; }

    public int AccountId { get; set; }

    public virtual Account Account { get; set; }
}
