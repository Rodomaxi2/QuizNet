using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> questionBuilder)
    {
        questionBuilder.HasKey(x => x.Id);
        questionBuilder.HasMany(x => x.Choice).WithOne(y => y.Question).OnDelete(DeleteBehavior.Cascade);
        questionBuilder.Property(x => x.QuestionText).HasMaxLength(50).IsRequired();
    }
}