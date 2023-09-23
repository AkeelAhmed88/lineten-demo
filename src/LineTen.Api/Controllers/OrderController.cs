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
        public async Task<ActionResult<IEnumerable<OrderResponse>>> Get()
        {
            var result = await _service.GetAllOrdersAsync();

            return result.Any() ? Ok(result) : NotFound();
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderResponse>> Get(int id)
        {
            var result = await _service.GetOrderByIdAsync(id);

            return result != null ? Ok(result) : NotFound();
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult<OrderResponse>> Post([FromBody] OrderCreateRequest request)
        {
            var result = await _service.CreateOrderAsync(request);

            return result != null ? Created(string.Empty, result) : BadRequest();
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<OrderResponse>> Put(int id, [FromBody] OrderUpdateRequest request)
        {
            var result = await _service.UpdateOrderByIdAsync(id, request);

            return result != null ? Ok(result) : NotFound();
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteOrderByIdAsync(id);

            return result == true ? NoContent() : BadRequest();
        }
    }
}
