using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.Core.Abstraction.IRepositories;
using TicketManagement.Core.Abstraction.IServices;
using TicketManagement.Core.Features.Ticket.Queries.GetTicketsList;
using TicketManagement.Domain.Entities;
using TicketManagement.Domain.Enums;
using TicketManagement.Domain.Helper;

namespace TicketManagement.Infrastrucure.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        public async Task<Tickets> AddAsync(Tickets entity)
        {
            entity.CreationDate = DateTime.Now;
            entity.Status = TicketStatus.New;
            var ticket = await _ticketRepository.AddAsync(entity);
            return ticket;

        }

        public async Task<PaginatedList<GetTicketsResponse>> GetTicketsWithPaging(int pageNumber, int pageSize)
        {
            return await _ticketRepository.GetTicketsWithPaging(pageNumber, pageSize);

        }
    }
}
