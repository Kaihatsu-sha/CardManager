using Kaihatsu.CardManager.CardAPI.Request;
using Kaihatsu.CardManager.CardAPI.Response;
using Kaihatsu.CardManager.Core.Interfaces;
using Kaihatsu.CardManager.DAL.Entities;
using Kaihatsu.CardManager.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Kaihatsu.CardManager.CardAPI.Controllers;

[Route("api/cards")]
[ApiController]
public class CardApiController : ControllerBase
{
    private readonly ILogger<CardApiController> _logger;
    private readonly ICardRepositoryAsync _repository;

    public CardApiController(ICardRepositoryAsync repository, ILogger<CardApiController> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    [HttpPost("create")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create([FromBody] CreateCardRequest request, CancellationToken cancellationToken = default)
    {
        try
        {
            var createdCard = await _repository.CreateAsync(new Kaihatsu.CardManager.DAL.Entities.Card
            {
                ClientId = request.ClientId,
                CardNumber = request.CardNo,
                ExpDate = request.ExpDate,
                CVV2 = request.CVV2
            }, cancellationToken);

            return Ok(new CreateCardResponse
            {
                Card = createdCard
            });
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Create card error.");
            return Ok(new CreateCardResponse
            {
                ErrorCode = 1012,
                ErrorMessage = "Create card error."
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

            return Ok(new GetAllCardResponse
            {
                Cards = createdClient.ToList()
            });
        }
        catch (Exception e)
        {
            _logger.LogError(e, "GetAll card error.");
            return Ok(new GetAllCardResponse
            {
                ErrorCode = 1011,
                ErrorMessage = "GetAll card error."
            });
        }
    }

    [HttpPost("getById")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByIdAsync([FromBody] GetByIdCardRequest request, CancellationToken cancellationToken = default)
    {
        try
        {
            var createdClient = await _repository.GetByIdAsync(request.Id, cancellationToken);

            return Ok(new GetByIdCardResponse
            {
                Card = createdClient
            });
        }
        catch (Exception e)
        {
            _logger.LogError(e, "GetById card error.");
            return Ok(new GetByIdCardResponse
            {
                ErrorCode = 1011,
                ErrorMessage = "GetById card error."
            });
        }
    }

    [HttpPost("update")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateCardRequest request, CancellationToken cancellationToken = default)
    {
        try
        {
            var createdClient = await _repository.UpdateAsync(new Kaihatsu.CardManager.DAL.Entities.Card
            {
                ClientId = request.ClientId,
                CardNumber = request.CardNo,
                Name = request.Name,
                CVV2 = request.CVV2,
                ExpDate = request.ExpDate
                
            }, cancellationToken);

            return Ok(new UpdateCardResponse
            {
                Card = createdClient
            });
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Update card error.");
            return Ok(new UpdateCardResponse
            {
                ErrorCode = 1011,
                ErrorMessage = "Update card error."
            });
        }
    }

    [HttpPost("delete")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete([FromBody] DeleteCardRequest request, CancellationToken cancellationToken = default)
    {
        try
        {
            var createdClient = await _repository.DeleteAsync(new Kaihatsu.CardManager.DAL.Entities.Card
            {
                ClientId = request.ClientId,
                CardNumber = request.CardNo,
                Name = request.Name,
                CVV2 = request.CVV2,
                ExpDate = request.ExpDate

            }, cancellationToken);

            return Ok(new DeleteCardResponse
            {
                Card = createdClient
            });
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Delete card error.");
            return Ok(new DeleteCardResponse
            {
                ErrorCode = 1011,
                ErrorMessage = "Delete card error."
            });
        }
    }

}
