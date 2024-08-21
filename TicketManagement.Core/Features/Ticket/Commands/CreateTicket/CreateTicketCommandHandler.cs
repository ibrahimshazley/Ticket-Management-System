using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketManagement.Core.Abstraction.IRepositories;
using TicketManagement.Core.Abstraction.IServices;
using TicketManagement.Domain.Entities;

namespace TicketManagement.Core.Features.Ticket.Commands.CreateTicket
{
    public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ITicketService _ticketService;

        public CreateTicketCommandHandler(IMapper mapper, ITicketService ticketService)
        {
           _mapper = mapper;
          _ticketService = ticketService;
        }
        public async Task<int> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            Tickets ticket = _mapper.Map<Tickets>(request);
            CreateTicketValidator validator = new CreateTicketValidator();
            var result = await validator.ValidateAsync(request);
            if (result.Errors.Any())
            {
                throw new Exception("Ticket Is Valid");
            }
            ticket = await _ticketService.AddAsync(ticket);
            return ticket.Id;
        }
    }
}
