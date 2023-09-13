using System;

using R5T.T0132;
using R5T.T0172;
using R5T.T0213;
using R5T.T0213.Extensions;

using AssemblyName = System.Reflection.AssemblyName;


namespace R5T.L0056
{
    [FunctionalityMarker]
    public partial interface IAssemblyOperator : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        private static L0053.IAssemblyOperator _Platform => L0053.AssemblyOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles
    }
}
