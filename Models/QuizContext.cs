using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace poll_api.Models;

public class QuizContext: DbContext
{
    public DbSet<User> Users {get; set;}
    public DbSet<UserChoice> UserChoice {get; set;}
    public DbSet<Question> Questions {get; set;}
    public DbSet<Choice> Choices {get; set;}

    public QuizContext(DbContextOptions<QuizContext> options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Podemos agregar todas las configuraciones usando...
        // modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // Tambien podemos aplicar cada una de las configuraciones y saber exactamente cuales se cargan
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new ChoiceConfiguration());
        modelBuilder.ApplyConfiguration(new QuestionConfiguration());
        modelBuilder.ApplyConfiguration(new UserChoiceConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.LogTo(Console.WriteLine).EnableSensitiveDataLogging(true);
        optionsBuilder.UseSqlServer("Data Source=(local); Initial Catalog=QuizDB;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True");
    }
}