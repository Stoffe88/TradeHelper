using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TradeHelper.Models;

namespace TradeHelper.Database.EntityConfigurations
{
    public class StockTransactionConfiguration : IEntityTypeConfiguration<StockTransaction>
    {
        public void Configure(EntityTypeBuilder<StockTransaction> builder)
        {
            builder.HasBaseType<Transaction>();

            builder.Property(transaction => transaction.StockCount)
                .IsRequired();               

            builder.HasOne(transaction => transaction.Stock)
                .WithMany(stock => stock.Transactions)
                .HasForeignKey(transaction => transaction.StockId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
