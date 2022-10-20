using AutoMapper;
using Grpc.Core;
using Kaihatsu.CardManager.CardgRPC.Protos;
using Kaihatsu.CardManager.DAL.Entities;
using Kaihatsu.CardManager.DAL.Interfaces;
using static Kaihatsu.CardManager.CardgRPC.Protos.ClientService;

namespace Kaihatsu.CardManager.CardgRPC.Services;

public class ClientSer : ClientServiceBase
{
    private readonly ILogger<ClientSer> _logger;
    private readonly IClientRepositoryAsync _repository;
    private readonly IMapper _mapper;


    public ClientSer(IClientRepositoryAsync repository, ILogger<ClientSer> logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public override async Task<CreateClientResponse> Create(CreateClientRequest request, ServerCallContext context)
    {
        var response = new CreateClientResponse();

        try
        {
            Client? createdClient = await _repository.CreateAsync(_mapper.Map<Client>(request), CancellationToken.None);

            response = new CreateClientResponse
            {
                Id = createdClient.Id.ToString()
            };
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Create client error.");
            response = new CreateClientResponse
            {
                ErrorCode = 1011,
                ErrorMessage = "Create client error."
            };
        }

        return response;
    }
}
