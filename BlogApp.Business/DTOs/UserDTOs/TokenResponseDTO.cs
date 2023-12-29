using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.UserDTOs
{
	public record TokenResponseDTO
	{
        public string Token { get; set; }
        public string UserName { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
