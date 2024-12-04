using System.Reflection;

namespace UserService;

public sealed class AssemblyReference
{
    internal static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
