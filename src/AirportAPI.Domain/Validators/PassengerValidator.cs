using Domain.Entities;
using FluentValidation;

namespace Domain.Validators;

public class PassengerValidator : AbstractValidator<Passenger>
{
    public PassengerValidator()
    {
        RuleFor(passenger => passenger.Name).NotEmpty();
    }
}