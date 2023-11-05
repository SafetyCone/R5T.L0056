using System;
using System.Collections.Generic;
using System.Linq;

using R5T.N0000;

using R5T.T0132;
using R5T.T0179.Extensions;
using R5T.T0180;
using R5T.T0180.Extensions;
using R5T.T0181;
using R5T.T0181.Extensions;
using R5T.T0199;


namespace R5T.L0056.N001
{
    /// <summary>
    /// For file-extension specific functionality.
    /// </summary>
    [FunctionalityMarker]
    public partial interface IFileSystemOperator : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        private static N000.IFileSystemOperator _N000 => N000.FileSystemOperator.Instance;
        private static L0053.N001.IFileSystemOperator _Platform => L0053.N001.FileSystemOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


        public IEnumerable<(IDirectoryPath, T)> EnumerateChildDirectories_OfType<T>(
            IDirectoryPath directoryPath,
            Func<IDirectoryName, WasFound<T>> directoryNameDiscriminator)
        {
            var childDirectoryPaths = _N000._Platform.Enumerate_ChildDirectoryPaths(directoryPath.Value);

            var priorDirectoryDates = childDirectoryPaths
               .Select(directoryPath => new { DirectoryPath = directoryPath.ToDirectoryPath(), DirectoryName = Instances.PathOperator.Get_DirectoryName(directoryPath).ToDirectoryName() })
               .Select(pair => new { pair.DirectoryPath, WasFound = directoryNameDiscriminator(pair.DirectoryName) })
               .Where(pair => pair.WasFound)
               .Select(pair => (pair.DirectoryPath, pair.WasFound.Result))
               ;

            return priorDirectoryDates;
        }

        public IEnumerable<(IDirectoryPath DirectoryPath, DateTime DirectoryDateTime)> EnumerateChildDirectories_YYYYMMDD(
            IDirectoryPath directoryPath)
        {
            var priorDirectoryDates = this.EnumerateChildDirectories_OfType(
                directoryPath,
                directoryName => Instances.DateTimeOperator.Is_YYYYMMDD(directoryName.Value));

            return priorDirectoryDates;
        }

        public IEnumerable<(IDirectoryPath DirectoryPath, DateTime DirectoryDateTime)> EnumerateChildDirectories_YYYYMMDD_HHMMSS(
            IDirectoryPath directoryPath)
        {
            var priorDirectoryDates = this.EnumerateChildDirectories_OfType(
                directoryPath,
                directoryName => Instances.DateTimeOperator.Is_YYYYMMDD_HHMMSS(directoryName.Value));

            return priorDirectoryDates;
        }

        /// <inheritdoc cref="Enumerate_ChildDllFilePaths"/>
        public IEnumerable<IDllFilePath> Enumerate_DllFilePaths(IDirectoryPath directoryPath)
        {
            return this.Enumerate_ChildDllFilePaths(directoryPath);
        }

        /// <summary>
        /// Enumerates child DLL files in the directory.
        /// </summary>
        public IEnumerable<IDllFilePath> Enumerate_ChildDllFilePaths(IDirectoryPath directoryPath)
        {
            return _Platform.Enumerate_DllFiles(directoryPath.Value)
                .To(x => x.ToDllFilePath())
                ;
        }

        /// <inheritdoc cref="Enumerate_ChildXmlFilePaths"/>
        public IEnumerable<IXmlFilePath> Enumerate_XmlFilePaths(IDirectoryPath directoryPath)
        {
            return this.Enumerate_ChildXmlFilePaths(directoryPath);
        }

        /// <summary>
        /// Enumerates child XML files in the directory.
        /// </summary>
        public IEnumerable<IXmlFilePath> Enumerate_ChildXmlFilePaths(IDirectoryPath directoryPath)
        {
            return _Platform.Enumerate_XmlFiles(directoryPath.Value)
                .To(x => x.ToXmlFilePath())
                ;
        }

        /// <inheritdoc cref="Enumerate_DllFilePaths"/>
        public IDllFilePath[] Get_DllFilePaths(IDirectoryPath directoryPath)
        {
            var output = this.Enumerate_DllFilePaths(directoryPath)
                .Now();

            return output;
        }

        public IXmlFilePath[] Get_XmlFilePaths(IDirectoryPath directoryPath)
        {
            var output = this.Enumerate_XmlFilePaths(directoryPath)
                .Now();

            return output;
        }
    }
}
