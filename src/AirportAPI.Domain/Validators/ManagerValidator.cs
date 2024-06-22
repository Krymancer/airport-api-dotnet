using Domain.Entities;
using FluentValidation;

namespace Domain.Validators;

public class ManagerValidator : AbstractValidator<Manager>
{
    public ManagerValidator()
    {
        RuleFor(manager => manager.Name).NotEmpty();
        RuleFor(manager => manager.Username).NotEmpty();
        RuleFor(manager => manager.Username).Length(4);
        RuleFor(manager => manager.Password).NotEmpty();
    }
}