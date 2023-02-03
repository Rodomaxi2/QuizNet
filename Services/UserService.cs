using poll_api.Models;

namespace poll_api.Services;

public class UserService : IUserService
{
    QuizContext context;

    public UserService(QuizContext dbContext)
    {
        context = dbContext;
    }

    // Metodos para manipular el modelo
    public IEnumerable<User> Get()
    {
        return context.Users;
    }

    public User GetById(Guid id)
    {
        return context.Users.Find(id);
    }

    public async Task Add(User user)
    {
        if(user != null)
        {
            user.Id = Guid.NewGuid();
            await context.AddAsync(user);
            await context.SaveChangesAsync();
        }
    }

    public async Task Update(Guid id, User user)
    {
        var currentUser = context.Users.Find(id);
        if(currentUser != null)
        {
            currentUser.UserName = user.UserName;
            await context.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id)
    {
        var currentUser = context.Users.Find(id);
        if(currentUser != null)
        {
            context.Remove(currentUser);
            await context.SaveChangesAsync();
        }
    }
}

public interface IUserService
{
    IEnumerable<User> Get();
    public User GetById(Guid id);
    Task Add(User user);
    Task Update(Guid id, User user);
    Task Delete(Guid id);
}