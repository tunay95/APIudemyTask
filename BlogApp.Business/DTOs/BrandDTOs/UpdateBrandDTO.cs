using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.BrandDTOs
{
    public class UpdateBrandDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class UpdateBrandDTOValidation : AbstractValidator<UpdateBrandDTO>
    {
        public UpdateBrandDTOValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Field bos ola bilmez")
                .NotNull()
                .WithMessage("Bos olmasin");
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("Id dogru deil");
        }
    }
}
