namespace Kaihatsu.CardManager.CardAPI.Request;

public class CreateClientRequest
{
    public string? Surname { get; set; }

    public string? FirstName { get; set; }

    public string? Patronymic { get; set; }
}


public class GetByIdClientRequest
{
    public Guid Id { get; set; }
}

public class UpdateClientRequest : CreateClientRequest
{
}

public class DeleteClientRequest : CreateClientRequest
{
}