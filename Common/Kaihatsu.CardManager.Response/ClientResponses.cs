using Kaihatsu.CardManager.Core.Interfaces;
using Kaihatsu.CardManager.DAL.Entities;

namespace Kaihatsu.CardManager.Response;

public class CreateClientResponse : IResponse
{
    public Client? Client { get; set; }
    public int ErrorCode { get; set; }
    public string? ErrorMessage { get; set; }
}

public class GetAllClientResponse : IResponse
{
    public List<Client>? Clients { get; set; }
    public int ErrorCode { get; set; }
    public string? ErrorMessage { get; set; }
}

public class GetByIdClientResponse : CreateClientResponse
{
}

public class UpdateClientResponse : CreateClientResponse
{
}

public class DeleteClientResponse : CreateClientResponse
{
}
