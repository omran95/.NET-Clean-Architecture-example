using Identity.Src.Domain.Common.Models;
using Identity.Src.Domain.User.ValueObjects;

namespace Identity.Src.Domain.User;

public class User : AggregateRoot<UserId>
{
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public string Password { get; }
    public DateOnly BirthDate { get; }

    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private User(string firstName, string lastName, string email, string password, DateOnly birthDate, UserId? userId = null) : base(userId ?? UserId.CreateUnique())
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        BirthDate = birthDate;

    }

    public static User create(string firstName, string lastName, string email, string password, DateOnly birthDate)
    {
        return new User(firstName, lastName, email, password, birthDate);
    }

}

