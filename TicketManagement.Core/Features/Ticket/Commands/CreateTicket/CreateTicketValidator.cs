using FluentValidation;

namespace TicketManagement.Core.Features.Ticket.Commands.CreateTicket
{
    public class CreateTicketValidator : AbstractValidator<CreateTicketCommand>
    {
        public CreateTicketValidator()
        {
            ApplyValidationsRules();
        }

        private void ApplyValidationsRules()
        {
            RuleFor(p => p.PhoneNumber)
                .NotEmpty()
                .NotNull();

        }
    }
}
