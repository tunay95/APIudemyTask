using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.BrandDTOs
{
    public class UpdateCategoryDTO
	{
        public int Id { get; set; }
        public string Title { get; set; }
		public int? ParentId { get; set; }
	}
    public class UpdateCategoryDTOValidation : AbstractValidator<UpdateCategoryDTO>
    {
        public UpdateCategoryDTOValidation()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Field cannot be empty !")
                .NotNull()
                .WithMessage("Don't Forget To Fill Title Section !");
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("Incorrect Id !");
           

        }
    }
}
