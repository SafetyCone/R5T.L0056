using System;

using R5T.T0132;


namespace R5T.L0056.Extensions
{
    [FunctionalityMarker]
    public partial interface IStringOperator : IFunctionalityMarker
    {
        /// <inheritdoc cref="IExecutableFilePath"/>
        public IExecutableFilePath ToExecutableFilePath(string value)
        {
            var output = new ExecutableFilePath(value);
            return output;
        }
    }
}
