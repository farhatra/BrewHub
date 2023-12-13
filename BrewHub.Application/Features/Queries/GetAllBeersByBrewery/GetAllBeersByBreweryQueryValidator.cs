using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewHub.Application.Features.Queries.GetAllBeersByBrewery
{
    public class GetAllBeersByBreweryQueryValidator : AbstractValidator<GetAllBeersByBreweryQuery>
    {
        public GetAllBeersByBreweryQueryValidator()
        {
            RuleFor(query => query.BreweryId).GreaterThan(0).WithMessage("Brewery ID must be greater than 0.");
        }
    }
}
