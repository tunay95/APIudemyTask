using BlogApp.Business.DTOs.BrandDTOs;
using BlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<ICollection<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task Update(UpdateCategoryDTO updateCategoryDTO);
        Task Create(CreateCategoryDTO createCategoryDTO);
        Task Delete(int id);

    }
}
