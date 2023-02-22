using poll_api.Models;

public interface IUserService
{
    IEnumerable<User> Get();
    User GetById(Guid id);
    Task Add(User user);
    Task Update(Guid id, User user);
    Task Delete(Guid id);
}