using Kaihatsu.CardManager.Core.Interfaces;
using Kaihatsu.CardManager.DAL.Entities;

namespace Kaihatsu.CardManager.Response;

public class CreateCardResponse : IResponse
{
    public Card? Card { get; set; }
    public int ErrorCode { get; set; }
    public string? ErrorMessage { get; set; }
}

public class GetAllCardResponse : IResponse
{
    public List<Card>? Cards { get; set; }
    public int ErrorCode { get; set; }
    public string? ErrorMessage { get; set; }
}

public class GetByIdCardResponse : CreateCardResponse
{
}

public class UpdateCardResponse : CreateCardResponse
{
}
public class DeleteCardResponse : CreateCardResponse
{
}