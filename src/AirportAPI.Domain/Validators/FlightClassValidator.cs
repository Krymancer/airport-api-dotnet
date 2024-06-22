using Domain.Entities;
using FluentValidation;

namespace Domain.Validators;

public class FlightClassValidator : AbstractValidator<FlightClass>
{
    public FlightClassValidator()
    {
        RuleFor(flightClass => flightClass.Seats).GreaterThan(0);
        RuleFor(flightClass => flightClass.SeatPrice).GreaterThan(0);
    }
}