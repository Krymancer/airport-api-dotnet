using Domain.Entities;
using FluentValidation;

namespace Domain.Validators;

public class TicketValidator : AbstractValidator<Ticket>
{
    public TicketValidator()
    {
        RuleFor(ticket => ticket.Identification).NotEmpty();
    }
}