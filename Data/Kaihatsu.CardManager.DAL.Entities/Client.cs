
using Kaihatsu.CardManager.Core;

namespace Kaihatsu.CardManager.DAL.Entities;

public class Client : BaseEntity
{
    public string? Surname { get; set; }

    public string? FirstName { get; set; }

    public string? Patronymic { get; set; }

    public virtual ICollection<Card> Cards { get; set; } = new HashSet<Card>();
}
