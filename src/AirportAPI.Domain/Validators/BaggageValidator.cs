using Domain.Entities;
using FluentValidation;

namespace Domain.Validators;

public class BaggageValidator : AbstractValidator<Baggage>
{
    public BaggageValidator()
    {
        RuleFor(baggage => baggage.Identification).NotEmpty();
    }
}