using BlogApp.Business.DTOs.BrandDTOs;
using BlogApp.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _service.GetAllAsync();
            return Ok(categories);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateCategoryDTO createCategoryDTO)
        {
            await _service.Create(createCategoryDTO);
            return StatusCode(StatusCodes.Status201Created);
        }





        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateCategoryDTO updateCategoryDTO)
        {
            await _service.Update(updateCategoryDTO);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
