using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradeHelper.Models;

namespace TradeHelper.Database.EntityConfigurations
{
    public class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.ToTable("Stock")
                .HasKey(stock => stock.Id);

            builder.Property(stock => stock.Name)
                .HasColumnType("VARCHAR(30)")
                .IsRequired();

            builder.Property(stock => stock.IsRemoved)
                .IsRequired();
        }
    }
}
