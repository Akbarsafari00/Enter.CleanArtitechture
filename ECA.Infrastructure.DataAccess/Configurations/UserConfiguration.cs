using ECA.Domain.AggregateModels.UserAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECA.Infrastructure.DataAccess.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(x => x.Username);
        
        builder.OwnsOne(x => x.Address, c =>
            {
                c.Property(x => x.Address).HasColumnName(nameof(UserAddress.Address));
                c.Property(x => x.City).HasColumnName(nameof(UserAddress.City));
                c.Property(x => x.PostalCode).HasColumnName(nameof(UserAddress.PostalCode));
            });
        
        builder.OwnsOne(x => x.Status, c =>
            {
                c.Property(x => x.Id)
                    .HasColumnName($"{nameof(User.Status)}Id");

                c.Property(x => x.Name)
                    .HasColumnName($"{nameof(User.Status)}");
            });
    }
}