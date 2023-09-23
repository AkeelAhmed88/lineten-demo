using LineTen.Api.Requests;
using LineTen.Api.Responses;
using LineTen.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LineTen.Api.Controllers
{
    /// <summary>
    /// Represents the API endpoint for managing customer-related operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerController"/> class.
        /// </summary>
        /// <param name="service">The customer service.</param>
        public CustomerController(ICustomerService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        /// <summary>
        /// Retrieves a list of all customers.
        /// </summary>
        /// <returns>A list of customer records.</returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CustomerResponse>))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<CustomerResponse>>> Get()
        {
            var result = await _service.GetAllCustomersAsync();

            return result.Any() ? Ok(result) : NotFound();
        }

        /// <summary>
        /// Retrieves a specific customer by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the customer.</param>
        /// <returns>The customer record, if found; otherwise, returns NotFound.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(CustomerResponse))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CustomerResponse>> Get(int id)
        {
            var result = await _service.GetCustomerByIdAsync(id);

            return result != null ? Ok(result) : NotFound();
        }

        /// <summary>
        /// Creates a new customer record.
        /// </summary>
        /// <param name="request">The customer data to be created.</param>
        /// <returns>The created customer record, if successful; otherwise, returns BadRequest.</returns>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(CustomerResponse))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<CustomerResponse>> Post([FromBody] CustomerRequest request)
        {
            var result = await _service.CreateCustomerAsync(request);

            return result != null ? Created(string.Empty, result) : BadRequest();
        }

        /// <summary>
        /// Updates an existing customer record by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the customer to be updated.</param>
        /// <param name="request">The updated customer data.</param>
        /// <returns>The updated customer record, if successful; otherwise, returns NotFound.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(CustomerResponse))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CustomerResponse>> Put(int id, [FromBody] CustomerRequest request)
        {
            var result = await _service.UpdateCustomerByIdAsync(id, request);

            return result != null ? Ok(result) : NotFound();
        }

        /// <summary>
        /// Deletes a customer record by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the customer to be deleted.</param>
        /// <returns>No content if the customer is successfully deleted; otherwise, returns BadRequest.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteCustomerByIdAsync(id);

            return result == true ? NoContent() : BadRequest();
        }
    }
}