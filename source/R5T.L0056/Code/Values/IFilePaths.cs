using System;

using R5T.T0131;
using R5T.T0181;


namespace R5T.L0056
{
    [ValuesMarker]
    public partial interface IFilePaths : IValuesMarker
    {
        /// <summary>
        /// Get the path of the currently executing executable file.
        /// </summary>
        public IExecutableFilePath Executable => Instances.ExecutablePathOperator.Get_ExecutableFilePath();
    }
}
