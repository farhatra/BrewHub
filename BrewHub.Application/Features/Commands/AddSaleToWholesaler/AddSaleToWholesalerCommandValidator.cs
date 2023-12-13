using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace BrewHub.Application.Features.Commands.AddSaleToWholesaler
{
    public class AddSaleToWholesalerCommandValidator : AbstractValidator<AddSaleToWholesalerCommand>
    {
        public AddSaleToWholesalerCommandValidator()
        {
            RuleFor(command => command.WholesalerId).GreaterThan(0).WithMessage("Wholesaler ID must be greater than 0.");
            RuleFor(command => command.BeerId).GreaterThan(0).WithMessage("Beer ID must be greater than 0.");
            RuleFor(command => command.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0.");
        }
    }
}
