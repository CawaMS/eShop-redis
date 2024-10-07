using eShop_API.Data;
using eShop_API.Interfaces;
using eShop_API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eShop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly eShopContext _context;
        private readonly IProductService _productService;

        public ProductsController(eShopContext context, IProductService productService)
        {
            _context = context;
            _productService = productService;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<List<Product>> Get()
        {
            return await _productService.GetAllProductsAsync();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<Product?> Get(int id)
        {
            return await _productService.GetProductByIdAsync(id);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task Post([FromBody] Product product)
        {
            await _productService.AddProduct(product);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
