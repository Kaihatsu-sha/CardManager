using AutoMapper;
using Kaihatsu.CardManager.DAL.Entities;
using Kaihatsu.CardManager.DAL.Interfaces;
using Kaihatsu.CardManager.Request;
using Kaihatsu.CardManager.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kaihatsu.CardManager.CardAPI.Controllers;

[Route("api/clients")]
[ApiController]
[Authorize]
public class ClientApiController : ControllerBase
{
    private readonly ILogger<CardApiController> _logger;
    private readonly IClientRepositoryAsync _repository;
    private readonly IMapper _mapper;

    public ClientApiController(IClientRepositoryAsync repository, ILogger<CardApiController> logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpPost("create")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create([FromBody] CreateClientRequest request, CancellationToken cancellationToken = default)
    {
        try
        {
            var createdClient = await _repository.CreateAsync(_mapper.Map<Client>(request), cancellationToken);

            return Ok(new CreateClientResponse
            {
                Client = createdClient
            });
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Create client error.");
            return Ok(new CreateClientResponse
            {
                ErrorCode = 1011,
                ErrorMessage = "Create client error."
            });
        }
    }

    [HttpGet("getAll")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
    {
        try
        {
            var createdClient = await _repository.GetAllAsync(cancellationToken);

            return Ok(new GetAllClientResponse
            {
                Clients = createdClient.ToList()
            });
        }
        catch (Exception e)
        {
            _logger.LogError(e, "GetAll client error.");
            return Ok(new GetAllClientResponse
            {
                ErrorCode = 1011,
                ErrorMessage = "GetAll client error."
            });
        }
    }

    [HttpPost("getById")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByIdAsync([FromBody] GetByIdClientRequest request, CancellationToken cancellationToken = default)
    {
        try
        {
            var createdClient = await _repository.GetByIdAsync(request.Id, cancellationToken);

            return Ok(new GetByIdClientResponse
            {
                Client = createdClient
            });
        }
        catch (Exception e)
        {
            _logger.LogError(e, "GetById client error.");
            return Ok(new GetByIdClientResponse
            {
                ErrorCode = 1011,
                ErrorMessage = "GetById client error."
            });
        }
    }

    [HttpPost("update")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateClientRequest request, CancellationToken cancellationToken = default)
    {
        try
        {
            var createdClient = await _repository.UpdateAsync(_mapper.Map<Client>(request), cancellationToken);

            return Ok(new UpdateClientResponse
            {
                Client = createdClient
            });
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Update client error.");
            return Ok(new UpdateClientResponse
            {
                ErrorCode = 1011,
                ErrorMessage = "Update client error."
            });
        }
    }
   
    [HttpPost("delete")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete([FromBody] DeleteClientRequest request, CancellationToken cancellationToken = default)
    {
        try
        {
            var createdClient = await _repository.DeleteAsync(_mapper.Map<Client>(request), cancellationToken);

            return Ok(new DeleteClientResponse
            {
                Client = createdClient
            });
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Delete client error.");
            return Ok(new DeleteClientResponse
            {
                ErrorCode = 1011,
                ErrorMessage = "Delete client error."
            });
        }
    }

}
