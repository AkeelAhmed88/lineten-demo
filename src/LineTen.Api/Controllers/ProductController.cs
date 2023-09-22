using LineTen.Api.Requests;
using LineTen.Api.Responses;
using LineTen.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LineTen.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IEnumerable<ProductResponse>> Get()
        {
            return await _service.GetAllProductsAsync();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ProductResponse> Get(int id)
        {
            return await _service.GetProductByIdAsync(id);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ProductResponse> Post([FromBody] ProductRequest request)
        {
            return await _service.CreateProductAsync(request);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<ProductResponse> Put(int id, [FromBody] ProductRequest request)
        {
            return await _service.UpdateProductByIdAsync(id, request);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _service.DeleteProductByIdAsync(id);
        }
    }
}
