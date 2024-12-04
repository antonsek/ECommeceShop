using System.Runtime.CompilerServices;

namespace Shared;


public static class Ensure
{
    public static void NotNullOrWhiteSpace(
        string? value,
        string? message = null,
        [CallerArgumentExpression("value")] string? paramName = null)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException(message ?? "The value can not be null", paramName);
        }
    }

    public static void NotNull(
        object? value,
        [CallerArgumentExpression("value")] string? paramName = null)
    {
        if (value is null)
        {
            throw new ArgumentNullException(paramName);
        }
    }

    public static void NotGreaterThan(
        int value,
        int maxValue,
        string? message = null,
        [CallerArgumentExpression("value")] string? paramName = null)
    {
        if (value > maxValue)
        {
            throw new ArgumentException(message, paramName);
        }
    }
    
    public static void NotEmpty(
        Guid value,
        string? message = null,
        [CallerArgumentExpression("value")] string? paramName = null)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException(message ?? "The value can not be null", paramName);
        }
    }
}