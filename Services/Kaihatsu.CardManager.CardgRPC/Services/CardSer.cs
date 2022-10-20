using AutoMapper;
using Grpc.Core;
using Kaihatsu.CardManager.CardgRPC.Protos;
using Kaihatsu.CardManager.DAL.Entities;
using Kaihatsu.CardManager.DAL.Interfaces;
using System.Threading;
using static Kaihatsu.CardManager.CardgRPC.Protos.CardService;
using Card = Kaihatsu.CardManager.DAL.Entities.Card;

namespace Kaihatsu.CardManager.CardgRPC.Services;

public class CardSer: CardServiceBase
{
    private readonly ILogger<CardSer> _logger;
    private readonly ICardRepositoryAsync _repository;
    private readonly IMapper _mapper;


    public CardSer(ICardRepositoryAsync repository, ILogger<CardSer> logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public override async Task<GetByIdCardResponse> GetByIdCard(GetByIdCardRequest request, ServerCallContext context)
    {
        var response = new GetByIdCardResponse();

        try
        {
            Card createdCard = await _repository.CreateAsync(_mapper.Map<Card>(request), CancellationToken.None);

            response = new GetByIdCardResponse
            {
                Id = createdCard.Id.ToString()
            };
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Create card error.");
            response = new GetByIdCardResponse
            {
                ErrorCode = 1012,
                ErrorMessage = "Create card error."
            };
        }

        return response;
    }
}
