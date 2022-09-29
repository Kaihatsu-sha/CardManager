
using Kaihatsu.CardManager.Core;

namespace Kaihatsu.CardManager.DAL.Entities;

public class Card : BaseEntity
{

    public string CardNumber { get; set; }

    public string? Name { get; set; }

    public string? CVV2 { get; set; }

    public DateTime ExpDate { get; set; }

    public virtual Client Client { get; set; }
    public Guid ClientId { get; set; }
}
