using BlogApp.Business.DTOs;
using BlogApp.Business.DTOs.BrandDTOs;
using BlogApp.Business.DTOs.UserDTOs;
using BlogApp.Business.Exceptions.User;
using BlogApp.Business.ExternalServices.Interfaces;
using BlogApp.Business.Services.Interfaces;
using BlogApp.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Services.Implementations
{
    public class AccountService:IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
		private readonly ITokenService _tokenService;

		public AccountService(UserManager<AppUser> userManager,ITokenService tokenService)
        {
            _userManager = userManager;
			_tokenService = tokenService;
		}
        public async Task Register(RegisterDTO registerDTO)
        {

            AppUser appUser = new AppUser()
            {
                Name = registerDTO.Name,
                Surname = registerDTO.Surname,
                Email = registerDTO.Email,
                UserName=registerDTO.Username
            };
            var result = await _userManager.CreateAsync(appUser,registerDTO.Password);
            if(!result.Succeeded)
            {
                throw new ArgumentException("Unable to Register");
            }
        }

		public async Task<TokenResponseDTO> LoginAsync(LoginDTO loginDTO)
		{
            var user = await _userManager.FindByNameAsync(loginDTO.UserNameOrEmail)?? await _userManager.FindByNameAsync(loginDTO.UserNameOrEmail);
		    if(user == null) throw new UserNotFoundException();
            if(!await _userManager.CheckPasswordAsync(user,loginDTO.Password)) throw new UserNotFoundException();

            return _tokenService.CreateToken(user,45);
		}

    }
}
