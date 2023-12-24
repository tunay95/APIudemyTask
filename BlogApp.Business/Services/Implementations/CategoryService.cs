using BlogApp.Business.DTOs.BrandDTOs;
using BlogApp.Business.Services.Interfaces;
using BlogApp.Core.Entities;
using BlogApp.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }


        public async Task<ICollection<Category>> GetAllAsync()
        {
            var categories = await _repository.GetAllAsync();
            return await categories.ToListAsync();
        }

        public async Task Update(UpdateCategoryDTO updateCategoryDTO) 
        {
            if(updateCategoryDTO == null)
            {
                throw new Exception("Form is Wrong");
            }

			Category category = await _repository.GetById(updateCategoryDTO.Id);

			category.Name = updateCategoryDTO.Name;

            await _repository.Update(category);
            await _repository.SavingChanges();
        }

        public async Task <Category> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Must be More than 0 ");
            }
            var category = await _repository.GetById(id);
            if(category == null)
            {
                throw new Exception("Brand not Found");

            }
            return category;
        }

        

        public async Task Create(CreateCategoryDTO createCategoryDTO)
        {
			Category category = new Category();
			category.Name = createCategoryDTO.Name;
			category.LogoUrl = createCategoryDTO.LogUrl;
            await _repository.Add(category);
            await _repository.SavingChanges();
        }

        public async Task Delete(int id)
        {
            if (id<=0)
            {
            throw new Exception("Id must be more than 0");
            }
            var category = await _repository.GetById(id);

            if(category == null)
            {
                throw new Exception("Brand not found");
            }
            _repository.Delete(category);
            await _repository.SavingChanges();
        }
    }
    
}
