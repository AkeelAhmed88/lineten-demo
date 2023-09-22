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
        public async Task<ActionResult<IEnumerable<ProductResponse>>> Get()
        {
            var result = await _service.GetAllProductsAsync();

            return result != null ? Ok(result) : BadRequest();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponse>> Get(int id)
        {
            var result = await _service.GetProductByIdAsync(id);

            return result != null ? Ok( result) : BadRequest();
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult<ProductResponse>> Post([FromBody] ProductRequest request)
        {
            var result = await _service.CreateProductAsync(request);

            return result != null ? Created(string.Empty, result) : BadRequest();
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductResponse>> Put(int id, [FromBody] ProductRequest request)
        {
            var result = await _service.UpdateProductByIdAsync(id, request);

            return result != null ? Ok(result) : NotFound();
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteProductByIdAsync(id);

            return result == true ? NoContent() : BadRequest();
        }
    }
}
