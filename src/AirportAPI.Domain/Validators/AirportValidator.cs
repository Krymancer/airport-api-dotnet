using Domain.Entities;
using FluentValidation;

namespace Domain.Validators;

public class AirportValidator : AbstractValidator<Airport>
{
    public AirportValidator()
    {
        RuleFor(airport => airport.Name).NotEmpty();
        RuleFor(airport => airport.IATACode).NotEmpty();
        RuleFor(airport => airport.IATACode).Matches(@"\b[A-Z]{3}[0-9]{3}\b");
    }
}