using Kaihatsu.CardManager.DAL.Entities;
using Kaihatsu.CardManager.DAL.Interfaces;
using Microsoft.Extensions.Logging;

namespace Kaihatsu.CardManager.DAL.Repository;

public class ClientRepositoryAsync : RepositoryBaseAsync<Client>, IClientRepositoryAsync
{
    private readonly ILogger<ClientRepositoryAsync> _logger;

    public ClientRepositoryAsync(CardManagerDbContext context, ILogger<ClientRepositoryAsync> logger) : base(context)
    {
        _logger = logger;
    }
}
