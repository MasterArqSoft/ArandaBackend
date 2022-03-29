using CodeFirst.Core.DTOs.Product.Requests;
using CodeFirst.Core.Interfaces.Services;
using CodeFirst.Domain.QueryFilters;
using CodeFirst.Domain.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace CodeFirst.Web.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _product;
        public ProductController(IProductService product)
        {
            _product = product;
        }

        [HttpGet("listado", Name = nameof(GetAllproduct))]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllproduct([FromQuery] ProductQueryFilter filters)
        {
            var students = _product.GetProducts(filters, Url.RouteUrl(nameof(GetAllproduct)).ToString());
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(students.Meta));
            return Ok(students);
        }

        [HttpGet("product/{id:int}", Name = "productById")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromRoute] long id)
        {
            return Ok(await _product.GetProductAsync(id).ConfigureAwait(false));
        }

        [HttpPost("product")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Post([FromBody] ProductAddDtoRequest product)
        {
            return Ok(await _product.AddProductAsync(product));
        }

        [HttpPut("product/{id:int}")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put([FromRoute] long id, [FromBody] ProductAddDtoRequest product)
        {
            return Ok(await _product.UpdateProductAsync(id, product));
        }

        [HttpDelete("product/{id:int}")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            return Ok(await _product.DeleteProductAsync(id));
        }
    }
}
