using LineTen.Api.Requests;
using LineTen.Api.Responses;
using LineTen.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LineTen.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerResponse>>> Get()
        {
            var result = await _service.GetAllCustomersAsync();

            return result.Any() ? Ok(result) : NotFound();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerResponse>> Get(int id)
        {
            var result = await _service.GetCustomerByIdAsync(id);

            return result != null ? Ok(result) : NotFound();
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<ActionResult<CustomerResponse>> Post([FromBody] CustomerRequest request)
        {
            var result = await _service.CreateCustomerAsync(request);

            return result != null ? Created(string.Empty, result) : BadRequest();
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerResponse>> Put(int id, [FromBody] CustomerRequest request)
        {
            var result = await _service.UpdateCustomerByIdAsync(id, request);

            return result != null ? Ok(result) : NotFound();
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteCustomerByIdAsync(id);

            return result == true ? NoContent() : BadRequest();
        }
    }
}
