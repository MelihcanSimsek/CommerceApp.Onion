﻿
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
    }
}
