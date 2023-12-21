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
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _repository;
        public BrandService(IBrandRepository repository)
        {
            _repository = repository;
        }


        public async Task<ICollection<Brand>> GetALlAsync()
        {
            var brands = await _repository.GetAllAsync();
            return await brands.ToListAsync();
        }

        public async Task Update(UpdateBrandDTO updateBrandDTO) 
        {
            if(updateBrandDTO == null)
            {
                throw new Exception("Form is Wrong");
            }

            Brand brand = await _repository.GetById(updateBrandDTO.Id);

            brand.Name = updateBrandDTO.Name;

            await _repository.Update(brand);
        }

        public async Task <Brand> GetById(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Must be More than 0 ");
            }
            var brand = await _repository.GetById(id);
            if(brand == null)
            {
                throw new Exception("Brand not Found");

            }
            return brand;
        }
    }
    
}
