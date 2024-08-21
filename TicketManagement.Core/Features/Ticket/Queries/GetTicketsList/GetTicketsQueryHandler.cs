using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.Core.Abstraction.IServices;
using TicketManagement.Domain.Helper;

namespace TicketManagement.Core.Features.Ticket.Queries.GetTicketsList
{
    public class GetTicketsQueryHandler : IRequestHandler<GetTicketsQuery, PaginatedList<GetTicketsResponse>>
    {
        ITicketService _ticketService;
        public GetTicketsQueryHandler(ITicketService ticketService) 
        { 
            _ticketService = ticketService;
        }
        public async Task<PaginatedList<GetTicketsResponse>> Handle(GetTicketsQuery request, CancellationToken cancellationToken)
        {
            return await _ticketService.GetTicketsWithPaging(request.PageNumber, request.PageSize);
        }


    }
}
