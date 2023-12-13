using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace BrewHub.Application.Features.Queries.RequestQuote
{
    public class RequestQuoteCommandValidator : AbstractValidator<RequestQuoteQuery>
    {
        //public RequestQuoteCommandValidator()
        //{
        //    RuleFor(command => command.WholesalerId).GreaterThan(0).WithMessage("Wholesaler ID must be greater than 0.");
        //    RuleFor(command => command.QuoteRequestDto.ClientId).NotEmpty().WithMessage("Client ID cannot be empty.");
        //    RuleFor(command => command.QuoteRequestDto.QuoteDetails).NotEmpty().WithMessage("Quote details cannot be empty.");
        //    RuleForEach(command => command.QuoteRequestDto.QuoteDetails).SetValidator(new QuoteDetailRequestValidator());
        //}

        //public class QuoteDetailRequestValidator : AbstractValidator<QuoteDetailRequest>
        //{
        //    public QuoteDetailRequestValidator()
        //    {
        //        RuleFor(detail => detail.BeerId).GreaterThan(0).WithMessage("Beer ID must be greater than 0.");
        //        RuleFor(detail => detail.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0.");
        //    }
        //}
    }
}
