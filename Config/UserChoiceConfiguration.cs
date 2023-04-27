using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using poll_api.Models;

public class UserChoiceConfiguration : IEntityTypeConfiguration<UserChoice>
{
    public void Configure(EntityTypeBuilder<UserChoice> userChoiceBuilder)
    {
        // LLave primaria compuesta por las llaves primarias de las otras tablas
        userChoiceBuilder.HasKey(x =>  new {x.IdUser, x.IdChoice});

        // Llave foranea, por cada usuario existen muchos UserChoice
        userChoiceBuilder.HasOne(x => x.User)
        .WithMany(y => y.UserChoice)
        .HasForeignKey(x => x.IdUser)
        .IsRequired();
        
        // Llave foranea, por cada choice existen muchos UserChoice
        userChoiceBuilder.HasOne(x => x.Choice)
        .WithMany(y => y.UserChoice)
        .HasForeignKey(x => x.IdChoice)
        .IsRequired();
    }
}