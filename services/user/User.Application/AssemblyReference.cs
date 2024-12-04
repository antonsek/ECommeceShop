using System.Reflection;

namespace Application;

public sealed class AssemblyReference
{
    internal static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
