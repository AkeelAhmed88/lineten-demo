using LineTen.Api.Requests;
using LineTen.Api.Responses;
using LineTen.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LineTen.Api.Controllers
{
    /// <summary>
    /// Represents the API endpoint for managing product-related operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController"/> class.
        /// </summary>
        /// <param name="service">The product service.</param>
        public ProductController(IProductService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        /// <summary>
        /// Retrieves a list of all products.
        /// </summary>
        /// <returns>A list of product records.</returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ProductResponse>))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IEnumerable<ProductResponse>>> Get()
        {
            var result = await _service.GetAllProductsAsync();

            return result.Any() ? Ok(result) : NotFound();
        }

        /// <summary>
        /// Retrieves a specific product by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product.</param>
        /// <returns>The product record, if found; otherwise, returns NotFound.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ProductResponse))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ProductResponse>> Get(int id)
        {
            var result = await _service.GetProductByIdAsync(id);

            return result != null ? Ok(result) : NotFound();
        }

        /// <summary>
        /// Creates a new product record.
        /// </summary>
        /// <param name="request">The product data to be created.</param>
        /// <returns>The created product record, if successful; otherwise, returns BadRequest.</returns>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ProductResponse))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ProductResponse>> Post([FromBody] ProductRequest request)
        {
            var result = await _service.CreateProductAsync(request);

            return result != null ? Created(string.Empty, result) : BadRequest();
        }

        /// <summary>
        /// Updates an existing product record by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product to be updated.</param>
        /// <param name="request">The updated product data.</param>
        /// <returns>The updated product record, if successful; otherwise, returns NotFound.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(ProductResponse))]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ProductResponse>> Put(int id, [FromBody] ProductRequest request)
        {
            var result = await _service.UpdateProductByIdAsync(id, request);

            return result != null ? Ok(result) : NotFound();
        }

        /// <summary>
        /// Deletes a product record by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product to be deleted.</param>
        /// <returns>No content if the product is successfully deleted; otherwise, returns BadRequest.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteProductByIdAsync(id);

            return result == true ? NoContent() : BadRequest();
        }
    }
}