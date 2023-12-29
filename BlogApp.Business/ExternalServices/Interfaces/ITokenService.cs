using BlogApp.Business.DTOs.UserDTOs;
using BlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.ExternalServices.Interfaces
{
	public interface ITokenService
	{
		TokenResponseDTO CreateToken(AppUser appUser, int expiredate);
	}
}
