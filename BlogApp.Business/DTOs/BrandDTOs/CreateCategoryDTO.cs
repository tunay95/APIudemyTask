using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.BrandDTOs
{
    public class CreateCategoryDTO
    {
        public string Name { get; set; }
        public string LogUrl { get; set; }
    }
    public class CreateCategoryDTOValidation : AbstractValidator<CreateCategoryDTO>
    {
        public CreateCategoryDTOValidation() 
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name Bos olmasin")
                .NotNull()
                .WithMessage("Field bos ola bilmez");
        }
    }
}
