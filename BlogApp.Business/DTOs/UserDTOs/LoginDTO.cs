using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.UserDTOs
{
	public record LoginDTO
	{
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; }
    }
    public class LoginDTOValidation : AbstractValidator<LoginDTO>
    {
        public LoginDTOValidation() 
        {
            RuleFor(l => l.UserNameOrEmail)
                .NotEmpty()
                .WithMessage("UserName or Email shouldn't be empty");
            RuleFor(l => l.Password)
                .NotEmpty()
                .WithMessage("Password shouldn't be empty");
        }
    }
}
