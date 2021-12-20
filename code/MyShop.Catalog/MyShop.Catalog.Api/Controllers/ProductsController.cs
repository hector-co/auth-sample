using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using MyShop.Catalog.Queries.Products;
using MyShop.Catalog.Commands.Products;
using Microsoft.AspNetCore.Authorization;
using Shared.Auth;
using static Shared.Auth.AuthConstants;

namespace MyShop.Catalog.Api.Controllers
{
    [Authorize]
    [Route("catalog/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
        {
            var getByIdQuery = new ProductDtoGetByIdQuery(id);
            var result = await _mediator.Send(getByIdQuery, cancellationToken);
            if (result.Data == null) return NotFound();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ProductDtoPagedQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [AuthorizeRoles(Roles.Administrator, Roles.Vendor)]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterProductCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);

            return Accepted();
        }
    }
}
