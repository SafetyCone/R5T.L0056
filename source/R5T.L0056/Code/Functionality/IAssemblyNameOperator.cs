using System;

using R5T.T0132;
using R5T.T0172;
using R5T.T0213;
using R5T.T0213.Extensions;


namespace R5T.L0056
{
    [FunctionalityMarker]
    public partial interface IAssemblyNameOperator : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        private static L0053.IAssemblyNameOperator _Platform => L0053.AssemblyNameOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


        public IFullAssemblyName Get_FullAssemblyName(IAssemblyFilePath assemblyFilePath)
        {
            var output = _Platform.Get_FullAssemblyName(
                assemblyFilePath.Value)
                .ToFullAssemblyName();

            return output;
        }
    }
}
