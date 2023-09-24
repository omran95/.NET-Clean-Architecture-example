using ErrorOr;

namespace Identity.Src.Domain.User;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict(
            code: "User.DuplicateEmail",
            description: "Email is already in use.");

        public static Error LessThan18 => Error.Validation(
            code: "User.LessThan18",
            description: "User must be at least 18 years old to register.");

        public static Error EmailNotExist => Error.NotFound(
            code: "User.EmailNotExist",
            description: "Email Doesn't exist.");

        public static Error InvalidCredentials => Error.Validation(
            code: "User.InvalidCredentials",
            description: "Invalid Credentials");

        public static Error AccountNotVerified => Error.Validation(code: "User.AccountNotVerified",
            description: "Account Not Verified");
    }
}
