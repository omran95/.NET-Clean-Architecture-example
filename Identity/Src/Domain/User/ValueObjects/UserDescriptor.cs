using Identity.Src.Domain.Common.Models;

namespace Identity.Src.Domain.User.ValueObjects;

public class UserDescriptor : ValueObject
{
    public UserId UserId { get; }
    public string Email { get; }
    public string Name { get; }
    public BirthDate BirthDate { get; }

    public UserDescriptor(User user)
	{
        Email= user.Email;
        UserId = user.Id;
        Name = $"{user.FirstName} {user.LastName}";
        BirthDate = user.BirthDate;
	}

    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return UserId;
        yield return Email;
        yield return Name;
        yield return BirthDate;
    }
}

