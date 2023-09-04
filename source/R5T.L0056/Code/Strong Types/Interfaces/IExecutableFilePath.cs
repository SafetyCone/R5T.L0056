using System;

using R5T.T0178;


namespace R5T.L0056
{
    /// <summary>
    /// Strongly-types a string as a .NET executable file path.
    /// </summary>
    [StrongTypeMarker]
    public interface IExecutableFilePath : IStrongTypeMarker,
        // .NET executables are executable.
        T0181.IExecutableFilePath,
        // .NET executables are also .NET assemblies.
        T0172.IAssemblyFilePath
    {
    }
}