using BlogApp.Business.DTOs;
using BlogApp.Business.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Services.Interfaces
{
    public interface IAccountService
    {
        Task Register (RegisterDTO registerDTO);
        Task<TokenResponseDTO> LoginAsync(LoginDTO loginDTO);

    }
}
