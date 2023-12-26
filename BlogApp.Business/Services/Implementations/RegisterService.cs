using BlogApp.Business.DTOs;
using BlogApp.Business.DTOs.BrandDTOs;
using BlogApp.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Services.Implementations
{
    public class RegisterService
    {
        private readonly UserManager<AppUser> _userManager;

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
            if(result.Succeeded)
            {
                throw new ArgumentException("Unable to Register");
            }
        }
    }
}
