using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs
{
    public record RegisterDTO
    {

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string RepeatPassword { get; set; }
    }
    public class RegisterDTOValidation : AbstractValidator<RegisterDTO>
    {
        public RegisterDTOValidation()
        {
            RuleFor(r => r.Name)
                .NotEmpty()
                .WithMessage("Name should not be empty !")
                .MaximumLength(30)
                .WithMessage("Size should be max 30 char.")
                .MinimumLength(3)
                .WithMessage("Size should be min 3 char.");

            RuleFor(r => r.Surname)
				.NotEmpty()
				.WithMessage("Surname should not be empty !")
				.MaximumLength(30)
				.WithMessage("Size should be max 30 char.")
				.MinimumLength(3)
				.WithMessage("Size should be min 3 char.");

            RuleFor(r => r.Username)
				.NotEmpty()
				.WithMessage("Username should not be empty !")
				.MaximumLength(30)
				.WithMessage("Size should be max 30 char.")
				.MinimumLength(3)
				.WithMessage("Size should be min 3 char.");

            RuleFor(r => r.Email)
                .NotEmpty()
                .WithMessage("Email should not be empty !")
                .Must(r =>
                {
                    Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    Match match = regex.Match(r);
                    return match.Success;
                })
                .WithMessage("Please Enter Email Correctly !");

            RuleFor(r => r.Password)
                .NotEmpty()
                .WithMessage("Password should not be empty !")
                .Must(p =>
                {
                    Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$");
                    Match match = regex.Match(p);
                    return match.Success;
                })
                .WithMessage("Please Wnter Password Correctly !");

            RuleFor(r => r)
                .Must(e => e.Password == e.RepeatPassword)
                .WithMessage("RepeatPassword should  be Same as Password !");
		}
    }
}
