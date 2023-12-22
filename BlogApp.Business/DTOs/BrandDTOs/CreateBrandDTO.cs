using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.BrandDTOs
{
    public class CreateBrandDTO
    {
        public string Name { get; set; }
        public string LogUrl { get; set; }
    }
    public class CreateBrandDTOValidation : AbstractValidator<CreateBrandDTO>
    {
        public CreateBrandDTOValidation() 
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name Bos olmasin")
                .NotNull()
                .WithMessage("Field bos ola bilmez");
        }
    }
}
