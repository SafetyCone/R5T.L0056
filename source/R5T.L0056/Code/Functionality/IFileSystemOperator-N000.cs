using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using R5T.N0003;

using R5T.T0132;
using R5T.T0179.Extensions;
using R5T.T0180;
using R5T.T0180.Extensions;
using R5T.T0221;


namespace R5T.L0056.N000
{
    /// <summary>
    /// For general functionality.
    /// </summary>
    [FunctionalityMarker]
    public partial interface IFileSystemOperator : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        public Platform.IFileSystemOperator _Platform => Platform.FileSystemOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


        public IEnumerable<IDirectoryPath> Enumerate_ChildDirectoryPaths(IDirectoryPath directoryPath)
        {
            var output = _Platform.Enumerate_ChildDirectoryPaths(
                directoryPath.Value)
                .To(x => x.ToDirectoryPath())
                ;

            return output;
        }

        public IEnumerable<IDirectoryPath> Enumerate_ChildDirectoryPaths(
            IDirectoryPath directoryPath,
            ISearchPattern searchPattern)
        {
            var output = _Platform.Enumerate_ChildDirectoryPaths(
                directoryPath.Value,
                searchPattern.Value)
                .To(x => x.ToDirectoryPath())
                ;

            return output;
        }

        public IEnumerable<IFilePath> Enumerate_ChildFilePaths(
            IDirectoryPath directoryPath,
            ISearchPattern searchPattern)
        {
            var output = _Platform.Enumerate_ChildFilePaths(
                directoryPath.Value,
                searchPattern.Value)
                .To(x => x.ToFilePath())
                ;

            return output;
        }

        public IEnumerable<IFilePath> Enumerate_ChildFilePaths(
            IDirectoryPath directoryPath,
            IFileExtension fileExtension)
        {
            var searchPattern = Instances.SearchPatternGenerator.Files_WithExtension(fileExtension);

            var output = this.Enumerate_ChildFilePaths(
                directoryPath,
                searchPattern);

            return output;
        }

        public IEnumerable<IFilePath> Enumerate_DescendantFilePaths(
            IDirectoryPath directoryPath,
            ISearchPattern searchPattern)
        {
            var output = _Platform.Enumerate_DescendantFilePaths(
                directoryPath.Value,
                searchPattern.Value)
                .To(x => x.ToFilePath())
                ;

            return output;
        }

        public bool Exists_File(IFilePath filePath)
        {
            var output = _Platform.Exists_File(filePath.Value);
            return output;
        }

        public IFilePath[] Get_ChildFilePaths(
            IDirectoryPath directoryPath,
            IFileExtension fileExtension)
        {
            var output = this.Enumerate_ChildFilePaths(
                directoryPath,
                fileExtension)
                .Now();

            return output;
        }

        public Func<IDirectoryPath, IEnumerable<IFilePath>> Get_Enumerate_ChildFilePaths(
            ISearchPattern searchPattern)
        {
            return directoryPath => this.Enumerate_ChildFilePaths(
                directoryPath,
                searchPattern);
        }

        public Func<IDirectoryPath, IEnumerable<IFilePath>> Get_Enumerate_DescendantFilePaths(
            ISearchPattern searchPattern)
        {
            return directoryPath => this.Enumerate_DescendantFilePaths(
                directoryPath,
                searchPattern);
        }

        /// <summary>
        /// Allows stating that a file path exists without spending the time to check with the file system to verify that it does.
        /// (To verify, see <see cref="Verify_FilePathExists{TFilePath}(TFilePath)"/>.)
        /// </summary>
        public FilePathExists<TFilePath> State_FilePathExists<TFilePath>(TFilePath filePath)
        {
            var output = FilePathExists.From(filePath);
            return output;
        }

        /// <summary>
        /// Tests whether the file path exists, and if it does returns a structure communicating that fact.
        /// If the file does not exist, throws a <see cref="FileNotFoundException"/>.
        /// (If want to assume the file path exists and not spend time checking, use <see cref="State_FilePathExists{TFilePath}(TFilePath)"/>.)
        /// </summary>
        public FilePathExists<TFilePath> Verify_FilePathExists<TFilePath>(TFilePath filePath)
            where TFilePath : IFilePath
        {
            var exists = this.Exists_File(filePath);

            if(!exists)
            {
                throw new FileNotFoundException("File does not exist.", filePath.Value);
            }

            var output = FilePathExists.From(filePath);
            return output;
        }
    }
}
