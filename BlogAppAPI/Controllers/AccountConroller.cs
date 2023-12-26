using BlogApp.Business.DTOs;
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
        private readonly IRegisterService _registeredServices;

        public AccountConroller(IRegisterService registeredServices)
        {
            _registeredServices = registeredServices;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register([FromForm]RegisterDTO registerDTO)
        {

            await _registeredServices.Register(registerDTO);
            return StatusCode(StatusCodes.Status200OK);
      
        }
    }
}
