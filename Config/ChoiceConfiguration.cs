using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using poll_api.Models;

public class ChoiceConfiguration : IEntityTypeConfiguration<Choice>
{
    public void Configure(EntityTypeBuilder<Choice> choiceBuilder)
    {
        choiceBuilder.HasKey(p => p.Id);

        // choiceBuilder.HasOne(x => x.Question)
        // .WithMany(y => y.Choices)
        // .HasForeignKey(x => x.IdQuestion);
        
        choiceBuilder.Property(x => x.ChoiceText).HasMaxLength(30).IsRequired();
        
        choiceBuilder.Property(x => x.Correct).HasDefaultValue(false);
    }
}