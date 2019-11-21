using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradeHelper.Models;

namespace TradeHelper.Database.EntityConfigurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transaction")
                .HasKey(transaction => transaction.Id);

            builder.Property(transaction => transaction.Type)
                .HasColumnType("INT")
                .IsRequired();

            builder.Property(transaction => transaction.Date)
                .HasColumnType("DATETIME")
                .IsRequired();

            builder.Property(transaction => transaction.Amount)
                .IsRequired();
        }
    }
}
