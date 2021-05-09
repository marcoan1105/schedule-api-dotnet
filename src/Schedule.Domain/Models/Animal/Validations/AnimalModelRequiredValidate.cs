using FluentValidation;
using Schedule.Domain.Models;

namespace Schedule.Domain.Validations
{
    public class AnimalModelRequiredValidate : AbstractValidator<AnimalModel>
    {
        public AnimalModelRequiredValidate()
        {
            RuleFor(e => e.Name)
                .NotNull()
                .Must((a, b) => a.Name != "")
                .WithMessage("Name is required 3");

            RuleFor(e => e.PropleId)
                .NotNull()
                .WithMessage("People Id is required 3");

            RuleFor(e => e.AnimalTypeId)
                .NotNull()
                .WithMessage("Animal Type Id is required 3");
        }
    }
}