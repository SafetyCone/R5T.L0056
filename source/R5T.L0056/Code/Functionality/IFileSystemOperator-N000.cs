using System;
using System.Collections.Generic;

using R5T.T0132;
using R5T.T0179.Extensions;
using R5T.T0180;
using R5T.T0180.Extensions;
using R5T.T0199;


namespace R5T.L0056.N000
{
    [FunctionalityMarker]
    public partial interface IFileSystemOperator : IFunctionalityMarker
    {
        private static L0053.IFileSystemOperator Platform => L0053.FileSystemOperator.Instance;


        public IEnumerable<IFilePath> Enumerate_ChildFilePaths(
            IDirectoryPath directoryPath,
            ISearchPattern searchPattern)
        {
            var output = Platform.Enumerate_ChildFilePaths(
                directoryPath.Value,
                searchPattern.Value)
                .To(x => x.ToFilePath())
                ;

            return output;
        }

        public Func<IDirectoryPath, IEnumerable<IFilePath>> Get_Enumerate_ChildFilePaths(
            ISearchPattern searchPattern)
        {
            return directoryPath => this.Enumerate_ChildFilePaths(
                directoryPath,
                searchPattern);
        }

        public IEnumerable<IFilePath> Enumerate_DescendantFilePaths(
            IDirectoryPath directoryPath,
            ISearchPattern searchPattern)
        {
            var output = Platform.Enumerate_DescendantFilePaths(
                directoryPath.Value,
                searchPattern.Value)
                .To(x => x.ToFilePath())
                ;

            return output;
        }

        public Func<IDirectoryPath, IEnumerable<IFilePath>> Get_Enumerate_DescendantFilePaths(
            ISearchPattern searchPattern)
        {
            return directoryPath => this.Enumerate_DescendantFilePaths(
                directoryPath,
                searchPattern);
        }
    }
}
