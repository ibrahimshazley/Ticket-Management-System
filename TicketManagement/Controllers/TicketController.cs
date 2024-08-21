using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketManagement.Core.Features.Ticket.Commands.CreateTicket;
using TicketManagement.Core.Features.Ticket.Queries.GetTicketsList;

namespace TicketManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TicketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("CreateTicket")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateTicketCommand createTicketCommand)
        {
            int id = await _mediator.Send(createTicketCommand);
            return Ok(id);
        }

        [HttpGet]
        [Route("GetTicketsWithPagination")]
        public async Task<IActionResult> GetTickets([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var result = await _mediator.Send(new GetTicketsQuery { PageNumber = pageNumber, PageSize = pageSize });
            return Ok(result);
        }


    }
}
