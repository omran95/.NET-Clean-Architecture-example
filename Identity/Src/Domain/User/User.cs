using Identity.Src.Domain.Common.Models;
using Identity.Src.Domain.User.ValueObjects;
using ErrorOr;

namespace Identity.Src.Domain.User;

public class User : AggregateRoot<UserId>
{
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public string Password { get; }
    public UserStatus Status { get; }
    public BirthDate BirthDate { get; }
    public string VerificationCode { get; }

    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private User(UserId Id, string firstName, string lastName, string email, string password, UserStatus status, BirthDate birthDate, string verificationCode) : base(Id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        Status = status;
        BirthDate = birthDate;
        VerificationCode = verificationCode;
    }

    public UserDescriptor UserDescriptor()
    {
        return new UserDescriptor(this);
    }

    public static ErrorOr<User> Create(string firstName, string lastName, string email, string password, DateOnly birthDate, string verificationCode)
    {
        BirthDate userBirthDate = BirthDate.Create(birthDate);
        if (!userBirthDate.GreaterThan18())
        {
            return Errors.User.LessThan18;
        }
        return new User(UserId.CreateUnique(), firstName, lastName, email, password, UserStatus.PendingVerification, userBirthDate, verificationCode);
    }

}
