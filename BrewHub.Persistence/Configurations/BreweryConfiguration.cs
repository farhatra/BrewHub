using BrewHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewHub.Persistence.Configurations
{
    public class BreweryConfiguration : IEntityTypeConfiguration<Brewery>
    {
        public void Configure(EntityTypeBuilder<Brewery> builder)
        {
            builder.HasKey(b => b.BreweryId);
            builder.Property(b => b.Name).IsRequired();
            builder.Property(b => b.Location).IsRequired();

            builder.HasMany(b => b.Beers)
                .WithOne(b => b.Brewery)
                .HasForeignKey(b => b.BreweryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class BeerConfiguration : IEntityTypeConfiguration<Beer>
    {
        public void Configure(EntityTypeBuilder<Beer> builder)
        {
            builder.HasKey(b => b.BeerId);
            builder.Property(b => b.Name).IsRequired();
            builder.Property(b => b.Type).IsRequired();
            builder.Property(b => b.Price).HasColumnType("decimal(18,2)").IsRequired();

            builder.HasOne(b => b.Brewery)
                .WithMany(b => b.Beers)
                .HasForeignKey(b => b.BreweryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(b => b.WholesalerBeers)
                .WithOne(wb => wb.Beer)
                .HasForeignKey(wb => wb.BeerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

    public class WholesalerConfiguration : IEntityTypeConfiguration<Wholesaler>
    {
        public void Configure(EntityTypeBuilder<Wholesaler> builder)
        {
            builder.HasKey(w => w.WholesalerId);
            builder.Property(w => w.Name).IsRequired();
            builder.Property(w => w.Stock).IsRequired();

            builder.HasMany(w => w.WholesalerBeers)
                .WithOne(wb => wb.Wholesaler)
                .HasForeignKey(wb => wb.WholesalerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(w => w.Quotes)
                .WithOne(q => q.Wholesaler)
                .HasForeignKey(q => q.WholesalerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class WholesalerBeerConfiguration : IEntityTypeConfiguration<WholesalerBeer>
    {
        public void Configure(EntityTypeBuilder<WholesalerBeer> builder)
        {
            builder.HasKey(wb => new { wb.WholesalerId, wb.BeerId });
            builder.Property(wb => wb.RemainingQuantity).IsRequired();

            builder.HasOne(wb => wb.Wholesaler)
                .WithMany(w => w.WholesalerBeers)
                .HasForeignKey(wb => wb.WholesalerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(wb => wb.Beer)
                .WithMany(b => b.WholesalerBeers)
                .HasForeignKey(wb => wb.BeerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class QuoteConfiguration : IEntityTypeConfiguration<Quote>
    {
        public void Configure(EntityTypeBuilder<Quote> builder)
        {
            builder.HasKey(q => q.QuoteId);
            builder.Property(q => q.ClientId).IsRequired();
            builder.Property(q => q.TotalPrice).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(q => q.Summary);

            builder.HasOne(q => q.Wholesaler)
                .WithMany(w => w.Quotes)
                .HasForeignKey(q => q.WholesalerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(q => q.QuoteDetails)
                .WithOne(qd => qd.Quote)
                .HasForeignKey(qd => qd.QuoteId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class QuoteDetailConfiguration : IEntityTypeConfiguration<QuoteDetail>
    {
        public void Configure(EntityTypeBuilder<QuoteDetail> builder)
        {
            builder.HasKey(qd => qd.QuoteDetailId);
            builder.Property(qd => qd.Quantity).IsRequired();
            builder.Property(qd => qd.Discount).HasColumnType("decimal(18,2)").IsRequired();

            builder.HasOne(qd => qd.Quote)
                .WithMany(q => q.QuoteDetails)
                .HasForeignKey(qd => qd.QuoteId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(qd => qd.Beer)
                .WithMany()  // Corrected this line to remove the reference to WholesalerBeers
                .HasForeignKey(qd => qd.BeerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
