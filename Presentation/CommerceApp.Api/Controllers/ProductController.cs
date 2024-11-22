
using CommerceApp.Application.Features.Products.Commands.CreateProduct;
using CommerceApp.Application.Features.Products.Commands.DeleteProduct;
using CommerceApp.Application.Features.Products.Commands.UpdateProduct;
using CommerceApp.Application.Features.Products.Queries.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommerceApp.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await mediator.Send(new GetAllProductsQueryRequest()));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateProductCommandRequest request)
        {
            await mediator.Send(request);
            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteProductCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

    }
}
