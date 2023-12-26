using BlogApp.Core.Entities;
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
        public string Title { get; set; }
		public int ParentId { get; set; }
		
	}
    public class CreateCategoryDTOValidation : AbstractValidator<CreateCategoryDTO>
    {
        public CreateCategoryDTOValidation() 
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Title Field cannot be empty !")
                .NotNull()
                .WithMessage("Field cannot be null !");
			RuleFor(x => x.ParentId)
			   .NotEmpty()
			   .WithMessage("There's no Such Category w/This Id !");
		}
    }
}
