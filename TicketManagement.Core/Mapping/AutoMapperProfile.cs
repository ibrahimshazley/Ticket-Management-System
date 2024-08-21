using AutoMapper;
using TicketManagement.Core.Features.Ticket.Commands.CreateTicket;
using TicketManagement.Domain.Entities;

namespace TicketManagement.Core.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Tickets, CreateTicketCommand>().ReverseMap();

        }
    }
}
