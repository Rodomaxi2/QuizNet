using poll_api.Models;

namespace poll_api.Services;

public class UserService : IUserService
{
    private readonly ILogger<UserService> _logger;
    QuizContext context;

    public UserService(QuizContext dbContext, ILogger<UserService> logger)
    {
        _logger = logger;
        context = dbContext;
    }

    // Metodos para manipular el modelo
    public IEnumerable<User> Get()
    {
        var users = context.Users;
        _logger.LogDebug("#######Mostrando todos los usuarios##############");
        return users;
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
            _logger.LogDebug($"##############Agragando usuario: userName: {user.UserName} - id:{user.Id}#################");
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
        _logger.LogError("Usuario no encontrado");
    }

    public async Task Delete(Guid id)
    {
        var currentUser = context.Users.Find(id);
        if(currentUser != null)
        {
            context.Remove(currentUser);
            // ????
            // context.Remove<User>(currentUser);
            await context.SaveChangesAsync();
        }
    }
}