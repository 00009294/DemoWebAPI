using DemoWebAPI.Models;
using DemoWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.productService.GetAllAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery]Guid id)
        {
            return Ok(await this.productService.GetByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetByName([FromQuery]string name)
        {
            return Ok(await this.productService.GetByNameAsync(name));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            return Ok(await this.productService.CreateAsync(product));
        }

        [HttpPut]
        public async Task<IActionResult> Update(Guid id, Product product)
        {
            return Ok(await this.productService.UpdateAsync(id, product));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await this.productService.DeleteAsync(id));
        }

    }
}
