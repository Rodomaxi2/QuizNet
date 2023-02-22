using poll_api.Models;

namespace poll_api.Services;
public interface IQuestionServices
{
    IEnumerable<Question> Get();

    Question GetQuestById();

    Task Add();
}