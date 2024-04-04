using ApiRestaurant.Core.Application.DTO_S.Account;
using ApiRestaurant.Core.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestaurant.WebApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register-waiter")]
        public async Task<IActionResult> RegisterWaiterAsync(RegisterRequest request)
        {
            return Ok(await _accountService.RegisterWaiterAsync(request));
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost("register-admin")]
        public async Task<IActionResult> RegisterAdminAsync(RegisterRequest request)
        {
            return Ok(await _accountService.RegisterWaiterAsync(request));
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationRequest request)
        {
            return Ok(await _accountService.AuthenticateAsync(request));
        }
    }
}
