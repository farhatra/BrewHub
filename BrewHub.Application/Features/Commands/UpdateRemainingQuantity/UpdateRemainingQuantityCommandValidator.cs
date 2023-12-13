using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace BrewHub.Application.Features.Commands.UpdateRemainingQuantity
{
    public class UpdateRemainingQuantityCommandValidator : AbstractValidator<UpdateRemainingQuantityCommand>
    {
        public UpdateRemainingQuantityCommandValidator()
        {
            RuleFor(command => command.WholesalerId).GreaterThan(0).WithMessage("Wholesaler ID must be greater than 0.");
            RuleFor(command => command.BeerId).GreaterThan(0).WithMessage("Beer ID must be greater than 0.");
            RuleFor(command => command.NewQuantity).GreaterThan(0).WithMessage("New quantity must be greater than 0.");
        }
    }
}
