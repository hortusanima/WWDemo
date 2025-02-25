using MediatR;
using Microsoft.AspNetCore.Mvc;
using WWDemo.Api.Requests;
using WWDemo.Application.DTOs;
using WWDemo.Application.Products.Commands.AddProduct;
using WWDemo.Application.Products.Commands.DeleteProduct;
using WWDemo.Application.Products.Queries.GetAllProducts;
using WWDemo.Application.Products.Queries.GetProductBySerialNumber;

namespace WWDemo.Api.Controllers
{
    [Route("[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		public async Task<IActionResult> AddProduct(AddProductRequest request)
		{
			await _mediator.Send(new AddProductCommand
			{
				Name = request.Name,
				Price = request.Price,
				SerialNumber = request.SerialNumber,
            });

            return Ok();
        }

		[HttpGet]
        [ProducesResponseType(typeof(List<ProductRepresentation>), StatusCodes.Status200OK)]
        public async Task<List<ProductRepresentation>> GetAllProducts()
		{
			var result = await _mediator.Send(new GetAllProductsQuery());

			return result;
		}

		[HttpGet("serial-number")]
        [ProducesResponseType(typeof(ProductRepresentation), StatusCodes.Status200OK)]

        public async Task<ProductRepresentation> GetProductBySerialNumber([FromRoute(Name = "serial-number")]int serialNumber)
		{
            var result = await _mediator.Send(new GetProductBySerialNumberQuery()
			{
				SerialNumber = serialNumber.ToString()
			});// map serial number
            
			return result;
		}

		[HttpDelete]

		public async Task<IActionResult> DeleteProduct(DeleteProductRequest request)
		{
			await _mediator.Send(new DeleteProductCommand
			{
				SerialNumber = request.SerialNumber
			});

			
			return Ok();
			
		}
	}
}
