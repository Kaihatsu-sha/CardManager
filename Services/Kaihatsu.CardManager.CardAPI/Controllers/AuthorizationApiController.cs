using Kaihatsu.CardManager.Request;
using Kaihatsu.CardManager.Response;
using Kaihatsu.CardManager.DAL.Interfaces;
using Kaihatsu.CardManager.Identity.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using FluentValidation;
using FluentValidation.Results;

namespace Kaihatsu.CardManager.CardAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    [Authorize]
    public class AuthorizationApiController : ControllerBase
    {
        private readonly ILogger<AuthorizationApiController> _logger;
        private readonly IAuthorizationManager _manager;
        private readonly IAccountManager _accountManager;
        private readonly IValidator<AuthorizationRequest> _requestValidator;

        public AuthorizationApiController(
            IAuthorizationManager manager, 
            IAccountManager accountManager,
            ILogger<AuthorizationApiController> logger, 
            IValidator<AuthorizationRequest> validator)
        {
            _manager = manager;
            _logger = logger;
            _accountManager = accountManager;
            _requestValidator = validator;
        }

        [HttpPost("signin")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromBody] AuthorizationRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                
                ValidationResult validationResult = _requestValidator.Validate(request);
                if (!validationResult.IsValid)
                    return BadRequest(validationResult.ToDictionary());

                var ss = _manager.SignIn(request.Login, request.Password);

                Response.Headers.Add(HeaderNames.Authorization, "Bearer " + ss.AccessToken);

                return Ok(new AuthorizationResponse());
            }
            catch (Exception e)
            {
                _logger.LogError(e, "SignIn error.");
                return Ok(new AuthorizationResponse
                {
                    ErrorCode = 1012,
                    ErrorMessage = "SignIn error."
                });
            }
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] AuthorizationRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                _accountManager.Create(request.Login, request.Password);
                var ss = _manager.SignIn(request.Login, request.Password);
                Response.Headers.Add(HeaderNames.Authorization, "Bearer " + ss.AccessToken);

                return Ok(new AuthorizationResponse());
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Create user error.");
                return Ok(new AuthorizationResponse
                {
                    ErrorCode = 1012,
                    ErrorMessage = "Create user error."
                });
            }
        }
    }
}
