using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.Core.Abstraction.IRepositories;
using TicketManagement.Core.Features.Ticket.Queries.GetTicketsList;
using TicketManagement.Domain.Entities;
using TicketManagement.Domain.Helper;

namespace TicketManagement.Core.Abstraction.IServices
{
    public interface ITicketService
    {
        Task<Tickets> AddAsync(Tickets entity);
        Task<PaginatedList<GetTicketsResponse>> GetTicketsWithPaging(int pageNumber, int pageSize);
      


    }
}
