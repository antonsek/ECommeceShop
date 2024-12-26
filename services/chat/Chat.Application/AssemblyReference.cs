using System.Reflection;

namespace Chat.Application;

public sealed class AssemblyReference
{
    internal static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}

