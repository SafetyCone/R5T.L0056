using System;
using System.Collections.Generic;
using System.Linq;

using R5T.Linq;

using R5T.T0132;
using R5T.T0172;
using R5T.T0172.Extensions;
using R5T.T0180;


namespace R5T.L0056
{
    [FunctionalityMarker]
    public partial interface IAssemblyFilePathOperator : IFunctionalityMarker
    {
        public L0053.IAssemblyFilePathOperator _Platform => L0053.AssemblyFilePathOperator.Instance;


        public IAssemblyFilePath[] Get_AssemblyFilePaths(IDirectoryPath directoryPath)
        {
            var output = this._Platform.Get_AssemblyFilePaths(directoryPath.Value)
                .Select(IAssemblyFilePath.ToAssemblyFilePath)
                .Now();

            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Get_AssemblyDirectoryAssemblyFilePaths_Inclusive(IAssemblyFilePath)" path="/summary"/>
        /// </summary>
        /// <remarks>
        /// Chooses <see cref="Get_AssemblyDirectoryAssemblyFilePaths_Inclusive(IAssemblyFilePath)"/> as the default.
        /// </remarks>
        public IAssemblyFilePath[] Get_AssemblyDirectoryAssemblyFilePaths(IAssemblyFilePath assemblyFilePath)
        {
            var output = this.Get_AssemblyDirectoryAssemblyFilePaths_Inclusive(assemblyFilePath);
            return output;
        }

        /// <summary>
        /// Get all assemly file paths in the directory of the given assembly file.
        /// </summary>
        /// <remarks>
        /// Inclusive in the sense that the provided assembly file path is included in the output.
        /// </remarks>
        public IAssemblyFilePath[] Get_AssemblyDirectoryAssemblyFilePaths_Inclusive(IAssemblyFilePath assemblyFilePath)
        {
            var output = _Platform.Get_AssemblyFilePaths_InAssemblyDirectory(assemblyFilePath.Value)
                .Select(IAssemblyFilePath.ToAssemblyFilePath)
                .Now();

            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Get_AssemblyDirectoryAssemblyFilePaths_Inclusive(IAssemblyFilePath)" path="/summary"/>
        /// </summary>
        /// <remarks>
        /// Exclusive in the sense that the provided assembly file path is <em>not</em> included in the output.
        /// </remarks>
        public IAssemblyFilePath[] Get_AssemblyDirectoryAssemblyFilePaths_Exclusive(IAssemblyFilePath assemblyFilePath)
        {
            var output = _Platform.Get_AssemblyFilePaths_InAssemblyDirectory(assemblyFilePath.Value)
                .Except_If(Instances.PredicateOperator.Get_Equals(assemblyFilePath.Value))
                .Select(IAssemblyFilePath.ToAssemblyFilePath)
                .Now();

            return output;
        }

        public IAssemblyFilePath[] Get_DependencyAssemblyFilePaths(
            IAssemblyFilePath assemblyFilePath,
            IEnumerable<IAssemblyFilePath> runtimeAssemblyFilePaths,
            out Dictionary<IAssemblyFileName, IAssemblyFilePath[]> duplicateAssemblyFilePathsByAssemblyFileName)
        {
            var assemblyDirectoryAssemblyFilePaths = this.Get_AssemblyDirectoryAssemblyFilePaths_Exclusive(
                assemblyFilePath);

            var allDependencyAssemblyFilePaths = Instances.EnumerableOperator.Combine(
                assemblyDirectoryAssemblyFilePaths,
                runtimeAssemblyFilePaths);

            var dependencyAssemblyFilePaths = this.Get_Distinct_KeepFirst(
                allDependencyAssemblyFilePaths,
                // Ignore duplicates.
                out duplicateAssemblyFilePathsByAssemblyFileName);

            return dependencyAssemblyFilePaths;
        }

        public IAssemblyFilePath[] Get_Distinct_KeepFirst(
            IEnumerable<IAssemblyFilePath> assemblyFilePaths,
            out Dictionary<IAssemblyFileName, IAssemblyFilePath[]> duplicateAssemblyFilePathsByAssemblyFileName)
        {
            var output = Instances.EnumerableOperator.Get_Distinct_KeepFirst(
                assemblyFilePaths,
                assemblyFilePath => Instances.PathOperator.Get_FileName(assemblyFilePath.Value)
                    .ToAssemblyFileName(),
                out duplicateAssemblyFilePathsByAssemblyFileName);

            return output;
        }
    }
}
