using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;
using R5T.T0172;
using R5T.T0181;

using R5T.L0056.Extensions;


namespace R5T.L0056
{
    [FunctionalityMarker]
    public partial interface IExecutablePathOperator : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        private L0053.IExecutablePathOperator _Platform => L0053.ExecutablePathOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


        /// <inheritdoc cref="L0053.IExecutablePathOperator.Enumerate_AssemblyFilePaths"/>
        public IEnumerable<IAssemblyFilePath> Enumerate_AssemblyFilePaths()
        {
            var output = _Platform.Enumerate_AssemblyFilePaths()
                .Select(
                    T0172.Extensions.StringExtensions.ToAssemblyFilePath)
                ;

            return output;
        }

        /// <inheritdoc cref="L0053.IExecutablePathOperator.Get_AssemblyFilePaths"/>
        public IAssemblyFilePath[] Get_AssemblyFilePaths()
        {
            var output = this.Enumerate_AssemblyFilePaths()
                .Now();

            return output;
        }

        /// <inheritdoc cref="L0053.IExecutablePathOperator.Get_ExecutableFilePath"/>
        public IExecutableFilePath Get_ExecutableFilePath()
        {
            var output = _Platform.Get_ExecutableFilePath()
                .ToExecutableFilePath();

            return output;
        }
    }
}


namespace R5T.L0056
{
    using R5T.T0181.Extensions;


    public partial interface IExecutablePathOperator
    {
        /// <inheritdoc cref="L0053.IExecutablePathOperator.Get_ExecutableDirectoryPath()"/>
        public IExecutableDirectoryPath Get_ExecutableDirectoryPath()
        {
            var output = _Platform.Get_ExecutableDirectoryPath()
                .ToExecutableDirectoryPath();

            return output;
        }
    }
}
