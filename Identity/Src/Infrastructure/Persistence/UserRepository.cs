using Microsoft.EntityFrameworkCore;
using Identity.Src.Domain.User;

namespace Identity.Src.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private readonly IdentityDbContext _identityDbContext;

    public UserRepository(IdentityDbContext identityDbContext)
    {
        _identityDbContext = identityDbContext;
    }

    public async Task Add(User user)
    {
        await _identityDbContext.AddAsync(user);
        await _identityDbContext.SaveChangesAsync();
    }

    public async Task<User?> FindByEmail(string email)
    {
        return await _identityDbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
}

