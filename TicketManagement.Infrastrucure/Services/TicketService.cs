using Hangfire;
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
        private readonly IBackgroundJobClient _backgroundJobClient;

        public TicketService(ITicketRepository ticketRepository, IBackgroundJobClient backgroundJobClient)
        {
            _ticketRepository = ticketRepository;
            _backgroundJobClient = backgroundJobClient;

        }
        public async Task<Tickets> AddAsync(Tickets entity)
        {
            entity.CreationDate = DateTime.Now;
            entity.Status = TicketStatus.New;
            var ticket = await _ticketRepository.AddAsync(entity);
            ScheduleStatusAndColorUpdates(ticket.Id);

            return ticket;

        }

        public async Task<PaginatedList<GetTicketsResponse>> GetTicketsWithPaging(int pageNumber, int pageSize)
        {
            return await _ticketRepository.GetTicketsWithPaging(pageNumber, pageSize);

        }

      

        public async Task UpdateTicketColorAndStatus(int ticketId)
        {
            var ticket = await _ticketRepository.GetByIdAsync(ticketId);
            if (ticket == null) return;

            var timeSinceCreation = DateTime.Now - ticket.CreationDate;

            if (timeSinceCreation.TotalMinutes >= 60)
            {
                ticket.Color = "Red";
                ticket.Status = TicketStatus.Handled;
            }
            else if (timeSinceCreation.TotalMinutes >= 45)
            {
                ticket.Color = "Blue";
            }
            else if (timeSinceCreation.TotalMinutes >= 30)
            {
                ticket.Color = "Green";
            }
            else if (timeSinceCreation.TotalMinutes >= 15)
            {
                ticket.Color = "Yellow";
            }

            await _ticketRepository.UpdateAsync(ticket);
        }

            #region private 

            private void ScheduleStatusAndColorUpdates(int ticketId)
        {
            var now = DateTime.Now;

            // Schedule jobs to run at 15, 30, 45, and 60 minutes after creation
            _backgroundJobClient.Schedule(() => UpdateTicketColorAndStatus(ticketId), TimeSpan.FromMinutes(15));
            _backgroundJobClient.Schedule(() => UpdateTicketColorAndStatus(ticketId), TimeSpan.FromMinutes(30));
            _backgroundJobClient.Schedule(() => UpdateTicketColorAndStatus(ticketId), TimeSpan.FromMinutes(45));
            _backgroundJobClient.Schedule(() => UpdateTicketColorAndStatus(ticketId), TimeSpan.FromMinutes(60));
        }
        #endregion
    }
}
