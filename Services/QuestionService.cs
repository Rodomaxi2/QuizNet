using poll_api.Models;

namespace poll_api.Services;

public class QuestionService : IQuestionService
{
    QuizContext context;

    public QuestionService(QuizContext dbContext)
    {
        context = dbContext;
    }

    // Metodos para manipular el modelo
    public IEnumerable<Question> Get()
    {
        return context.Questions;
    }

    public async Task Add(Question question)
    {
        if(question != null)
        {
            await context.AddAsync(question);
            await context.SaveChangesAsync();
        }
    }

    public async Task Update(Guid id, Question question)
    {
        var currentQuestion = context.Questions.Find(id);
        if(currentQuestion != null)
        {
            currentQuestion.QuestionText = question.QuestionText;
            await context.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id)
    {
        var currentQuestion = context.Questions.Find(id);
        if(currentQuestion != null)
        {
            context.Remove(currentQuestion);
            await context.SaveChangesAsync();
        }
    }
}

public interface IQuestionService
{
    IEnumerable<Question> Get();
    Task Add(Question question);
    Task Update(Guid id, Question question);
    Task Delete(Guid id);
}