using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace BrewHub.Application.Features.Commands.AddNewBeer
{
    public class AddNewBeerCommandValidator : AbstractValidator<AddNewBeerCommand>
    {
        public AddNewBeerCommandValidator()
        {
            RuleFor(command => command.NewBeerDto.Name).NotEmpty().WithMessage("Beer name cannot be empty.");
            RuleFor(command => command.NewBeerDto.Type).NotEmpty().WithMessage("Beer type cannot be empty.");
            RuleFor(command => command.NewBeerDto.Price).GreaterThan(0).WithMessage("Beer price must be greater than 0.");
        }
    }
}
