using System;

using R5T.T0131;
using R5T.T0181;


namespace R5T.L0056
{
    [ValuesMarker]
    public partial interface IFilePaths : IValuesMarker
    {
        public IExecutableFilePath Executable => Instances.ExecutablePathOperator.Get_ExecutableFilePath();
    }
}
