using MayaBinance.Domain.Identity.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MayaBinance.DataAccess.ModelConfigurations.Identity
{
    public class UserConfig:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "identity");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Creator).WithMany().HasForeignKey(x => x.CreatorId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Modifier).WithMany().HasForeignKey(x => x.ModifierId).OnDelete(DeleteBehavior.NoAction);
            builder.Property(x => x.FirstName).IsUnicode().IsRequired().HasMaxLength(150);
            builder.Property(x => x.LastName).IsUnicode().IsRequired().HasMaxLength(150);
            builder.Property(x => x.EmailOrUserName).IsUnicode().IsRequired().HasMaxLength(150);
            builder.Property(x => x.Password).IsUnicode().IsRequired().HasMaxLength(1000);
            builder.OwnsOne(p => p.Address).Property(p => p.City).IsUnicode().HasMaxLength(150);
            builder.OwnsOne(p => p.Address).Property(p => p.Country).IsUnicode().HasMaxLength(150); 
            builder.OwnsOne(p => p.Address).Property(p => p.Street).IsUnicode().HasMaxLength(350); 
            builder.OwnsOne(p => p.Address).Property(p => p.ZipCode).IsUnicode().HasMaxLength(14); 
      

        }
    }
}
