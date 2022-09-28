namespace Kaihatsu.CardManager.CardAPI.Request;

public class CreateCardRequest
{
    public Guid ClientId { get; set; }

    public string CardNo { get; set; }

    public string? Name { get; set; }

    public string? CVV2 { get; set; }

    public DateTime ExpDate { get; set; }
}

public class GetByIdCardRequest
{
    public Guid Id { get; set; }
}

public class UpdateCardRequest : CreateCardRequest
{
}

public class DeleteCardRequest : CreateCardRequest
{
}