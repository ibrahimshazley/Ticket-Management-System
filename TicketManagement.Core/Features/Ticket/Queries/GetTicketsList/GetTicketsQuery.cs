using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.Domain.Helper;


namespace TicketManagement.Core.Features.Ticket.Queries.GetTicketsList
{
    public class GetTicketsQuery : IRequest<PaginatedList<GetTicketsResponse>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

  
}
