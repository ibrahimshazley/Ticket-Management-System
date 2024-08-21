using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.Core.Abstraction.IRepositories;
using TicketManagement.Core.Features.Ticket.Queries.GetTicketsList;
using TicketManagement.Domain.Entities;
using TicketManagement.Domain.Helper;
using TicketManagement.Infrastrucure.DBContext;

namespace TicketManagement.Infrastrucure.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        protected readonly ApplicationDBContext _dbContext;
        public TicketRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Tickets> AddAsync(Tickets entity)
        {
            await _dbContext.Tickets.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Tickets> GetByIdAsync(int id)
        {
            return await _dbContext.Tickets.FindAsync(id);
        }

        public Task<PaginatedList<GetTicketsResponse>> GetTicketsWithPaging(int pageNumber, int pageSize)
        {
            var query = _dbContext.Tickets
            .OrderByDescending(t => t.CreationDate)
            .Select(t => new GetTicketsResponse
            {
                Id = t.Id,
                PhoneNumber = t.PhoneNumber,
                CreationDate = t.CreationDate,
                Status = t.Status.ToString(),
                Color=t.Color,
                Governorate=t.Governorate,
                City=t.City,
                District=t.District

            }).AsNoTracking();
            return  PaginatedList<GetTicketsResponse>.CreateListAsync(query, pageNumber, pageSize);

        }

        public async Task UpdateAsync(Tickets entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
