using BlogApp.Business.DTOs;
using BlogApp.Business.DTOs.UserDTOs;
using BlogApp.Business.Services.Implementations;
using BlogApp.Business.Services.Interfaces;
using BlogApp.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace BlogApp.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountConroller:ControllerBase
    {
        private readonly IAccountService _registeredServices;

        public AccountConroller(IAccountService registeredServices)
        {
            _registeredServices = registeredServices;
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromForm]RegisterDTO registerDTO)
        {

            await _registeredServices.Register(registerDTO);
            return StatusCode(StatusCodes.Status200OK);
      
        }
		[HttpPost("[action]")]
		public async Task<IActionResult> Login([FromForm] LoginDTO loginDTO)
		{

			var result = await _registeredServices.LoginAsync(loginDTO);
			return Ok(result);

		}
	}
}
