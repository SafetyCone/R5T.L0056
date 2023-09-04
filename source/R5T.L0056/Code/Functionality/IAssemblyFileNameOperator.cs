using System;

using R5T.T0132;
using R5T.T0172;
using R5T.T0180;
using R5T.T0180.Extensions;
using R5T.T0213;


namespace R5T.L0056
{
    [FunctionalityMarker]
    public partial interface IAssemblyFileNameOperator : IFunctionalityMarker
    {
        public IAssemblyFileName Get_AssemblyFileName(IAssemblyName assemblyName)
        {
            var assemblyFileNameStem = this.Get_AssemblyFileNameStem(assemblyName);

            var output = this.Get_AssemblyFileName(assemblyFileNameStem);
            return output;
        }

        public IAssemblyFileName Get_AssemblyFileName(IFileNameStem assemblyFileNameStem)
        {
            var output = Instances.FileNameOperator.Get_FileName(
                assemblyFileNameStem,
                Instances.FileExtensions.Dll,
                T0172.Extensions.StringExtensions.ToAssemblyFileName);

            return output;
        }

        public IFileNameStem Get_AssemblyFileNameStem(IAssemblyName assemblyName)
        {
            return Instances.AssemblyFileNameOperator_Platform.Get_AssemblyFileNameStem(
                assemblyName.Value)
                .ToFileNameStem();
        }

        
    }
}
