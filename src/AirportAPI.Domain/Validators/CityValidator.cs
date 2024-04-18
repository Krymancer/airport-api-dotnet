using Domain.Entities;
using FluentValidation;

namespace Domain.Validators;

public class CityValidator : AbstractValidator<City>
{
    public CityValidator()
    {
        RuleFor(city => city.Name).NotEmpty();
        RuleFor(city => city.UF).NotEmpty().Length(2);
    }
}