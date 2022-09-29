using Kaihatsu.CardManager.DAL.Entities;
using Kaihatsu.CardManager.DAL.Interfaces;
using Microsoft.Extensions.Logging;

namespace Kaihatsu.CardManager.DAL.Repository;

public class CardRepositoryAsync : RepositoryBaseAsync<Card>, ICardRepositoryAsync
{
    private readonly ILogger<CardRepositoryAsync> _logger;

    public CardRepositoryAsync(CardManagerDbContext context, ILogger<CardRepositoryAsync> logger): base(context)
    {
        _logger = logger;
    }
}
