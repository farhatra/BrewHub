using System;
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
    public class Beer
    {
        public int BeerId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }

        public int BreweryId { get; set; }
        public Brewery Brewery { get; set; }

        public ICollection<WholesalerBeer> WholesalerBeers { get; set; }
    }
    public class Wholesaler
    {
        public int WholesalerId { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }

        public ICollection<WholesalerBeer> WholesalerBeers { get; set; }
        public ICollection<Quote> Quotes { get; set; }
    }
    public class WholesalerBeer
    {
        public int WholesalerId { get; set; }
        public Wholesaler Wholesaler { get; set; }

        public int BeerId { get; set; }
        public Beer Beer { get; set; }

        public int RemainingQuantity { get; set; }
    }
    public class Quote
    {
        public int QuoteId { get; set; }
        public int WholesalerId { get; set; }
        public Wholesaler Wholesaler { get; set; }
        public string ClientId { get; set; }
        public decimal TotalPrice { get; set; }
        public string Summary { get; set; }

        public ICollection<QuoteDetail> QuoteDetails { get; set; }
    }
    public class QuoteDetail
    {
        public int QuoteDetailId { get; set; }
        public int QuoteId { get; set; }
        public Quote Quote { get; set; }

        public int BeerId { get; set; }
        public Beer Beer { get; set; }

        public int Quantity { get; set; }
        public decimal Discount { get; set; }
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
