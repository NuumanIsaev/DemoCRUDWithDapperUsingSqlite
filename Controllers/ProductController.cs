using DemoCRUDwithDapperUsingSqlite.IService;
using DemoCRUDwithDapperUsingSqlite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DemoCRUDwithDapperUsingSqlite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService productService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var product = await productService.GetAllProductAsync();
            return product is null ? NotFound() : Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await productService.GetProductByIdAsync(id);
            return product is null ? NotFound() : Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            var result = await productService.AddProductAsync(product);
            if (result == 0) return 
                    BadRequest();
            else
                return CreatedAtAction(nameof(GetById), new {id = product.Id }, product);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Product product)
        {
            var result = await productService.UpdateProductAsync(product);
            return result > 0 ? NoContent() : BadRequest();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int productId)
        {
            int result = await productService.DeleteProductAsync(productId);
            return result > 0 ? NoContent() : BadRequest();
        }
    }
}
