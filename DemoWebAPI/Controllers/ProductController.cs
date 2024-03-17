﻿using DemoWebAPI.Models;
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
        public IActionResult GetAll()
        {
            return Ok(this.productService.GetAllAsync());
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetAll(string name)
        {
            return Ok(await this.productService.GetAllAsync(name));
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