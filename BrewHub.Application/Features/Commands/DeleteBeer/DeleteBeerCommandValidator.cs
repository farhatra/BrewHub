using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace BrewHub.Application.Features.Commands.DeleteBeer
{
    public class DeleteBeerCommandValidator : AbstractValidator<DeleteBeerCommand>
    {
        public DeleteBeerCommandValidator()
        {
            RuleFor(command => command.BeerId).GreaterThan(0).WithMessage("Beer ID must be greater than 0.");
        }
    }
}
