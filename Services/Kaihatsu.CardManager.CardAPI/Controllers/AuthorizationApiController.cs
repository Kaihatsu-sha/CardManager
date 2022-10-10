using Kaihatsu.CardManager.CardAPI.Request;
using Kaihatsu.CardManager.CardAPI.Response;
using Kaihatsu.CardManager.DAL.Interfaces;
using Kaihatsu.CardManager.Identity.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

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

        public AuthorizationApiController(IAuthorizationManager manager, IAccountManager accountManager,ILogger<AuthorizationApiController> logger)
        {
            _manager = manager;
            _logger = logger;
            _accountManager = accountManager;
        }

        [HttpPost("signin")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromBody] Requesto request, CancellationToken cancellationToken = default)
        {
            try
            {
                var ss = _manager.SignIn(request.Login, request.Password);

                Response.Headers.Add(HeaderNames.Authorization, "Bearer " + ss.AccessToken);

                return Ok(new CreateCardResponse
                {
                    Card = null
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

        [HttpPost("create")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] Requesto request, CancellationToken cancellationToken = default)
        {
            try
            {
                _accountManager.Create(request.Login, request.Password);
                var ss = _manager.SignIn(request.Login, request.Password);
                Response.Headers.Add(HeaderNames.Authorization, "Bearer " + ss.AccessToken);
                return Ok(new CreateCardResponse
                {
                    Card = null
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

        public class Requesto
        {
            public string Login { get; set; }
            public string Password { get; set; }
        }
    }
}
