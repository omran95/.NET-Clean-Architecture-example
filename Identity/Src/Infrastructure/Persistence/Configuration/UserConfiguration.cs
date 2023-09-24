using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Identity.Src.Domain.User;
using Identity.Src.Domain.User.ValueObjects;

namespace Identity.Src.Infrastructure.Persistence.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        ConfigureUsersTable(builder);
    }
    private void ConfigureUsersTable(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value));

        builder.Property(u => u.FirstName)
            .HasMaxLength(100);

        builder.Property(u => u.LastName)
            .HasMaxLength(100);

        builder.Property(u => u.Email)
            .HasMaxLength(100);

        builder.HasIndex(u => u.Email).IsUnique();

        builder.Property(u => u.Password)
            .HasMaxLength(100);

        builder.Property(u => u.BirthDate)
            .HasMaxLength(100)
            .HasConversion(
                birthDate => birthDate.Value,
                value => BirthDate.Create(value)
            );

        builder.Property(u => u.Status)
            .HasMaxLength(100)
            .HasConversion(
                model => model.ToString(),
                db => (UserStatus)Enum.Parse(typeof(UserStatus), db)
            );

        builder.Property(u => u.VerificationCode).HasMaxLength(100);
         
    }
}

