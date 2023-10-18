using System;
using System.Collections.Generic;
using System.Linq;
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
        private static L0053.N001.IFileSystemOperator Platform => L0053.N001.FileSystemOperator.Instance;


        /// <inheritdoc cref="Enumerate_ChildDllFiles"/>
        public IEnumerable<IDllFilePath> Enumerate_DllFiles(IDirectoryPath directoryPath)
        {
            return this.Enumerate_ChildDllFiles(directoryPath);
        }

        /// <summary>
        /// Enumerates child DLL files in the directory.
        /// </summary>
        public IEnumerable<IDllFilePath> Enumerate_ChildDllFiles(IDirectoryPath directoryPath)
        {
            return Platform.Enumerate_DllFiles(directoryPath.Value)
                .To(x => x.ToDllFilePath())
                ;
        }

        /// <inheritdoc cref="Enumerate_ChildXmlFiles"/>
        public IEnumerable<IDllFilePath> Enumerate_XmlFiles(IDirectoryPath directoryPath)
        {
            return this.Enumerate_ChildXmlFiles(directoryPath);
        }

        /// <summary>
        /// Enumerates child XML files in the directory.
        /// </summary>
        public IEnumerable<IDllFilePath> Enumerate_ChildXmlFiles(IDirectoryPath directoryPath)
        {
            return Platform.Enumerate_XmlFiles(directoryPath.Value)
                .To(x => x.ToDllFilePath())
                ;
        }

        /// <inheritdoc cref="Enumerate_DllFiles"/>
        public IDllFilePath[] Get_DllFiles(IDirectoryPath directoryPath)
        {
            var output = this.Enumerate_DllFiles(directoryPath)
                .Now();

            return output;
        }
    }
}
