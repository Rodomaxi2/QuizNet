using Microsoft.EntityFrameworkCore;

public class QuizContext: DbContext
{
    public DbSet<User> Users {get; set;}
    public DbSet<Vote> Votes {get; set;}
    public DbSet<Question> Questions {get; set;}
    public DbSet<Choice> Choices {get; set;}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}