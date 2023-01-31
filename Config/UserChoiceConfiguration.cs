using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using poll_api.Models;

public class UserChoiceConfiguration : IEntityTypeConfiguration<UserChoice>
{
    public void Configure(EntityTypeBuilder<UserChoice> userChoiceBuilder)
    {
        userChoiceBuilder.HasKey(x => x.Id);
        userChoiceBuilder.HasOne(x => x.User).WithMany(y => y.UserChoice).HasForeignKey(x => x.IdUser);
        userChoiceBuilder.HasOne(x => x.Choice).WithMany(y => y.UserChoice).HasForeignKey(x => x.IdChoice);
    }
}