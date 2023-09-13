using System;
using System.Reflection;

using R5T.T0132;
using R5T.T0172;
using R5T.T0213;
using R5T.T0213.Extensions;

using AssemblyName = System.Reflection.AssemblyName;


namespace R5T.L0056
{
    [FunctionalityMarker]
    public partial interface IAssemblyNameOperator : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        private static L0053.IAssemblyNameOperator _Platform => L0053.AssemblyNameOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


        public AssemblyName Get_AssemblyName(IAssemblyFilePath assemblyFilePath)
        {
            return _Platform.Get_AssemblyName(assemblyFilePath.Value);
        }

        public IFullAssemblyName Get_FullAssemblyName(IAssemblyFilePath assemblyFilePath)
        {
            var output = _Platform.Get_FullAssemblyName(assemblyFilePath.Value)
                .ToFullAssemblyName();

            return output;
        }
    }
}
