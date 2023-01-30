using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ChoiceConfiguration : IEntityTypeConfiguration<Choice>
{
    public void Configure(EntityTypeBuilder<Choice> choiceBuilder)
    {
        choiceBuilder.HasKey(p => p.Id);
        choiceBuilder.HasOne(x => x.Question).WithMany(y => y.Choice).HasForeignKey(x => x.IdQuestion);
        choiceBuilder.Property(x => x.ChoiceText).HasMaxLength(30).IsRequired();
        choiceBuilder.Property(x => x.Correct).HasDefaultValue(false);
    }
}