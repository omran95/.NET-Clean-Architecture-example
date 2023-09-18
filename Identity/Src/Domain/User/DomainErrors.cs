using ErrorOr;

namespace Identity.Src.Domain.User;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict(
            code: "User.DuplicateEmail",
            description: "Email is already in use.");

        public static Error LessThan18 => Error.Conflict(
            code: "User.LessThan18",
            description: "User must be at least 18 years old to register.");
    }
}
