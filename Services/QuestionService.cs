using poll_api.Models;

namespace poll_api.Services;

public class QuestionService : IQuestionService
{
    QuizContext context;
    private readonly ILogger<QuestionService> _logger;

    public QuestionService(QuizContext dbContext, ILogger<QuestionService> logger)
    {
        context = dbContext;
        this._logger = logger;
    }

    // Metodos para manipular el modelo
    public IEnumerable<Question> Get()
    {
        return context.Questions;
    }

    public Question GetQuestionById(Guid id)
    {
        var question = context.Questions.Find(id);

        if(question is null)
            _logger.LogError($"La pregunta con el id: {id} no se encontro");

        return question;
    }

    public async Task Add(Question question)
    {
        if(question is not null)
        {
            question.Id = Guid.NewGuid();
            await context.AddAsync(question);
            await context.SaveChangesAsync();
        }
        
        _logger.LogError("Es necesario texto para la pregunta");
    }

    public async Task Update(Guid id, Question question)
    {
        var currentQuestion = context.Questions.Find(id);
        if(currentQuestion != null)
        {
            currentQuestion.QuestionText = question.QuestionText;
            await context.SaveChangesAsync();
        }

        _logger.LogError($"La pregunta con el id: {id} no se encontro");
    }

    public async Task DeleteById(Guid id)
    {
        var currentQuestion = context.Questions.Find(id);
        if(currentQuestion != null)
        {
            context.Remove(currentQuestion);
            await context.SaveChangesAsync();
        }

        _logger.LogError($"La pregunta con el id: {id} no se encontro");
    }
}