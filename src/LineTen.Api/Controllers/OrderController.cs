using LineTen.Api.Requests;
using LineTen.Api.Responses;
using LineTen.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LineTen.Api.Controllers
{
    /// <summary>
    /// Represents the API endpoint for managing order-related operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderController"/> class.
        /// </summary>
        /// <param name="service">The order service.</param>
        public OrderController(IOrderService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        /// <summary>
        /// Retrieves a list of all orders.
        /// </summary>
        /// <returns>A list of order records.</returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OrderResponse>))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<OrderResponse>>> Get()
        {
            var result = await _service.GetAllOrdersAsync();

            return result.Any() ? Ok(result) : NotFound();
        }

        /// <summary>
        /// Retrieves a specific order by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the order.</param>
        /// <returns>The order record, if found; otherwise, returns NotFound.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(OrderResponse))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<OrderResponse>> Get(int id)
        {
            var result = await _service.GetOrderByIdAsync(id);

            return result != null ? Ok(result) : NotFound();
        }

        /// <summary>
        /// Creates a new order record.
        /// </summary>
        /// <param name="request">The order data to be created.</param>
        /// <returns>The created order record, if successful; otherwise, returns BadRequest.</returns>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(OrderResponse))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<OrderResponse>> Post([FromBody] OrderCreateRequest request)
        {
            var result = await _service.CreateOrderAsync(request);

            return result != null ? Created(string.Empty, result) : BadRequest();
        }

        /// <summary>
        /// Updates an existing order record by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the order to be updated.</param>
        /// <param name="request">The updated order data.</param>
        /// <returns>The updated order record, if successful; otherwise, returns NotFound.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(OrderResponse))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<OrderResponse>> Put(int id, [FromBody] OrderUpdateRequest request)
        {
            var result = await _service.UpdateOrderByIdAsync(id, request);

            return result != null ? Ok(result) : NotFound();
        }

        /// <summary>
        /// Deletes an order record by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the order to be deleted.</param>
        /// <returns>No content if the order is successfully deleted; otherwise, returns BadRequest.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteOrderByIdAsync(id);

            return result == true ? NoContent() : BadRequest();
        }
    }
}