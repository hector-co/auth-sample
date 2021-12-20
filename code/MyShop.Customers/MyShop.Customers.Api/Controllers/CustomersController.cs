using Microsoft.AspNetCore.Mvc;
using MediatR;
using MyShop.Customers.Queries.Customers;
using Shared.Auth;
using static Shared.Auth.AuthConstants;
using Microsoft.AspNetCore.Authorization;

namespace MyShop.Customers.Api.Controllers
{
    [Authorize]
    [Route("customers/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AuthorizeRoles(Roles.Administrator, Roles.Vendor, Roles.Customer)]
        [HttpGet("{id}", Name = "GetCustomerById")]
        public async Task<IActionResult> Get(int id, CancellationToken cancellationToken)
        {
            var getByIdQuery = new CustomerDtoGetByIdQuery(id);
            var result = await _mediator.Send(getByIdQuery, cancellationToken);
            if (result.Data == null) return NotFound();
            return Ok(result);
        }

        [AuthorizeRoles(Roles.Administrator, Roles.Vendor)]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] CustomerDtoPagedQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}
