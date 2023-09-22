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
        public async Task<IEnumerable<CustomerResponse>> Get()
        {
            return await _service.GetAllCustomersAsync();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public async Task<CustomerResponse> Get(int id)
        {
            return await _service.GetCustomerByIdAsync(id);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<CustomerResponse> Post([FromBody] CustomerRequest request)
        {
            return await _service.CreateCustomerAsync(request);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public async Task<CustomerResponse> Put(int id, [FromBody] CustomerRequest request)
        {
            return await _service.UpdateCustomerByIdAsync(id, request);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _service.DeleteCustomerByIdAsync(id);
        }
    }
}
