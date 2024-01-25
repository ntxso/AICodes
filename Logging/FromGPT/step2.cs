public class UserService
{
    private readonly YourDbContext _dbContext;
    private readonly LogService _logService;

    public UserService(YourDbContext dbContext, LogService logService)
    {
        _dbContext = dbContext;
        _logService = logService;
    }

    public void AddUser(User user)
    {
        try
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            _logService.LogInformation($"User with ID {user.Id} added successfully.");
        }
        catch (Exception ex)
        {
            _logService.LogError($"Error adding user with ID {user.Id}.", ex);
        }
    }

    // Other CRUD methods go here with similar log usage...
}
