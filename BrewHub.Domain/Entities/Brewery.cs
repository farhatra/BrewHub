﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewHub.Domain.Entities
{
    public class Brewery
    {
        public int BreweryId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public ICollection<Beer> Beers { get; set; }
    }

    //public class QuoteRequest
    //{
    //    public string ClientId { get; set; }
    //    public List<QuoteDetailRequest> QuoteDetails { get; set; }
    //}
    //// DTOs for QuoteDetailRequest
    //public class QuoteDetailRequest
    //{
    //    public int BeerId { get; set; }
    //    public int Quantity { get; set; }
    //}
}
