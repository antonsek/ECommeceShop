using System.Reflection;

namespace Chat.Api;

public sealed class AssemblyReference
{
    internal static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}

