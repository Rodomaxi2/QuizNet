using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using poll_api.Models;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> questionBuilder)
    {
        questionBuilder.HasKey(x => x.Id);
        // Debe de ponerse en un solo lado?
        questionBuilder.HasMany(x => x.Choices).WithOne(x => x.Question).HasForeignKey(x => x.Id);

        questionBuilder.Property(x => x.QuestionText).HasMaxLength(50).IsRequired();
    }
}