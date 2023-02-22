using poll_api.Models;

public interface IQuestionService
{
    IEnumerable<Question> Get();

    Question GetQuestionById(Guid id);

    Task Add(Question question);

    Task Update(Guid id, Question question);

    Task DeleteById(Guid id);
}