using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.Core.Features.Ticket.Queries.GetTicketsList;
using TicketManagement.Domain.Entities;
using TicketManagement.Domain.Helper;

namespace TicketManagement.Core.Abstraction.IRepositories
{
    public interface ITicketRepository 
    {
        Task<Tickets> AddAsync(Tickets entity);
        Task<Tickets> GetByIdAsync(int id);
        Task<PaginatedList<GetTicketsResponse>> GetTicketsWithPaging(int pageNumber, int pageSize);
        Task UpdateAsync(Tickets entity);


    }
}
