using MayaBinance.Domain.BaseModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MayaBinance.DataAccess.ModelConfigurations.BaseModels
{
    public class CoinConfiguration:IEntityTypeConfiguration<Coin>
    {
        public void Configure(EntityTypeBuilder<Coin> builder)
        {
            builder.ToTable("Coins", "Trade");
            builder.Property(x => x.Name).IsRequired().IsUnicode().HasMaxLength(500);
            builder.Property(x => x.Symbol).IsRequired().IsUnicode().HasMaxLength(100);
            builder.Property(x => x.Symbol).IsRequired().IsUnicode().HasMaxLength(100);
            builder.Property(x => x.Icon).IsUnicode().HasMaxLength(100);
            builder.Property(x => x.IsActive).IsRequired();
        }
    }
}
