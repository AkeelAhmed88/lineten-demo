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
        public IEnumerable<ProductResponse> Get()
        {
            throw new NotImplementedException();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ProductResponse Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST api/<ProductController>
        [HttpPost]
        public int Post([FromBody] ProductRequest request)
        {
            throw new NotImplementedException();
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProductRequest request)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
