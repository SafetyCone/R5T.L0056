using System;

using R5T.T0178;
using R5T.T0179;


namespace R5T.L0056
{
    /// <inheritdoc cref="IExecutableFilePath"/>
    [StrongTypeImplementationMarker]
    public class ExecutableFilePath : TypedBase<string>, IStrongTypeMarker,
        IExecutableFilePath
    {
        public ExecutableFilePath(string value)
            : base(value)
        {
        }
    }
}