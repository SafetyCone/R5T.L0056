using System;

using R5T.T0132;
using R5T.T0172;
using R5T.T0172.Extensions;
using R5T.T0227;
using R5T.T0227.Extensions;


namespace R5T.L0056
{
    [FunctionalityMarker]
    public partial interface IRuntimeEnvironmentOperator : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        public L0053.IRuntimeEnvironmentOperator _Platform => L0053.RuntimeEnvironmentOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


        /// <inheritdoc cref="L0053.IRuntimeEnvironmentOperator.Get_CurrentlyExecutingRuntime_CoreAssemblyFilePath"/>
        public IAssemblyFilePath Get_CurrentlyExecutingRuntime_CoreAssemblyFilePath()
        {
            var output = _Platform.Get_CurrentlyExecutingRuntime_CoreAssemblyFilePath()
                .ToAssemblyFilePath();

            return output;
        }

        /// <inheritdoc cref="L0053.IRuntimeEnvironmentOperator.Get_RuntimeDirectoryPath"/>
        public IRuntimeDirectoryPath Get_RuntimeDirectoryPath()
        {
            var output = _Platform.Get_RuntimeDirectoryPath()
                .ToRuntimeDirectoryPath();

            return output;
        }
    }
}
