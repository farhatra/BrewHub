using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewHub.Application.Features.DtoModels
{
    public class BeerDto
    {
        public int BeerId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
    }

    // DTOs for Wholesaler
    public class WholesalerDto
    {
        public int WholesalerId { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
    }

    // DTOs for Quote
    public class QuoteDto
    {
        public int QuoteId { get; set; }
        public int WholesalerId { get; set; }
        public decimal TotalPrice { get; set; }
        public string Summary { get; set; }
        public List<QuoteDetailDto> QuoteDetails { get; set; }
    }

    // DTOs for QuoteDetail
    public class QuoteDetailDto
    {
        public int QuoteDetailId { get; set; }
        public int BeerId { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
    }
    // DTOs for QuoteRequest
    public class QuoteRequestDto
    {
        public string ClientId { get; set; }
        public List<QuoteDetailRequestDto> QuoteDetailsDto { get; set; }
    }
    // DTOs for QuoteDetailRequest
    public class QuoteDetailRequestDto
    {
        public int BeerId { get; set; }
        public int Quantity { get; set; }
    }
}
//    public class WholesalerDto
//    {
//        public int WholesalerId { get; set; }
//        public string Name { get; set; }
//        public int Stock { get; set; }
//        public ICollection<WholesalerBeerDto> WholesalerBeers { get; set; }
//        public ICollection<QuoteDto> Quotes { get; set; }
//    }
//    public class WholesalerBeerDto
//    {
//        public int BeerId { get; set; }
//        public BeerDto Beer { get; set; }
//        public int RemainingQuantity { get; set; }
//    }
//    public class QuoteDto
//    {
//        public int QuoteId { get; set; }
//        public int WholesalerId { get; set; }
//        public WholesalerDto Wholesaler { get; set; }
//        public string ClientId { get; set; }
//        public decimal TotalPrice { get; set; }
//        public string Summary { get; set; }
//        public ICollection<QuoteDetailDto> QuoteDetails { get; set; }
//    }
//    public class QuoteDetailDto
//    {
//        public int QuoteDetailId { get; set; }
//        public int QuoteId { get; set; }
//        public QuoteDto Quote { get; set; }
//        public int BeerId { get; set; }
//        public BeerDto Beer { get; set; }
//        public int Quantity { get; set; }
//        public decimal Discount { get; set; }
//    }
//    public class QuoteRequestDto
//    {
//        public string ClientId { get; set; }
//        public List<QuoteDetailRequestDto> QuoteDetails { get; set; }
//    }
//    public class QuoteDetailRequestDto
//    {
//        public int BeerId { get; set; }
//        public int Quantity { get; set; }
//    }

//}
