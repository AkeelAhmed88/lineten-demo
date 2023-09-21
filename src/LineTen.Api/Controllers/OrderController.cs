using LineTen.Api.Requests;
using LineTen.Api.Responses;
using LineTen.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LineTen.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<OrderResponse> Get()
        {
            throw new NotImplementedException();
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public OrderResponse Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST api/<OrderController>
        [HttpPost]
        public int Post([FromBody] OrderCreateRequest request)
        {
            throw new NotImplementedException();
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] OrderUpdateRequest request)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
