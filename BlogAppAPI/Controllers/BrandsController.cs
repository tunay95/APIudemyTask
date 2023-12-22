using BlogApp.Business.DTOs.BrandDTOs;
using BlogApp.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _service;
        public BrandsController(IBrandService service)
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
        public async Task<IActionResult> Create([FromForm]CreateBrandDTO createBrandDTO)
        {
            await _service.Create(createBrandDTO);
            return StatusCode(StatusCodes.Status201Created);
        }





        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateBrandDTO updateBrandDTO)
        {
            await _service.Update(updateBrandDTO);
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
