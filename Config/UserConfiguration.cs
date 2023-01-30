using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> userBuilder)
    {
        userBuilder.HasKey(p => p.Id);
        userBuilder.Property(p => p.UserName).HasMaxLength(20).IsRequired();
    }
}