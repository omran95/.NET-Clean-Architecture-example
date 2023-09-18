using System;
using Identity.Src.Domain.Common.Models;

namespace Identity.Src.Domain.User.ValueObjects;

public class BirthDate : ValueObject
{
    public DateOnly Value { get; }

    public BirthDate(DateOnly value)
    {
        Value = value;
    }

    public int GetAge()
    {
        var yearOfBirth = Value.Year;
        var currentYear = DateTime.Today.Year;
        return currentYear - yearOfBirth;
    }

    public bool GreaterThan18()
    {
        int age = GetAge();
        if (age < 18)
        {
            return false;
        }
        return true;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}

