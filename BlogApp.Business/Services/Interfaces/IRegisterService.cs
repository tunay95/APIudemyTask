using BlogApp.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Services.Interfaces
{
    public interface IRegisterService
    {
        Task Register (RegisterDTO registerDTO);
    }
}
