namespace Identity.Src.Domain.User;

public interface IUserRepository
{
    Task<User?> FindByEmail(string email);
    Task<User> Add(User user);
}

