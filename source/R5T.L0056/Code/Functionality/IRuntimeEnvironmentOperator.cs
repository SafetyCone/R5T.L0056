using System;

using R5T.T0132;
using R5T.T0227;
using R5T.T0227.Extensions;


namespace R5T.L0056
{
    [FunctionalityMarker]
    public partial interface IRuntimeEnvironmentOperator : IFunctionalityMarker,
        L0053.IRuntimeEnvironmentOperator
    {
        private static L0053.IRuntimeEnvironmentOperator Platform => L0053.RuntimeEnvironmentOperator.Instance;


        /// <inheritdoc cref="L0053.IRuntimeEnvironmentOperator.Get_RuntimeDirectoryPath"/>
        public new IRuntimeDirectoryPath Get_RuntimeDirectoryPath()
        {
            var output = Platform.Get_RuntimeDirectoryPath()
                .ToRuntimeDirectoryPath();

            return output;
        }
    }
}
