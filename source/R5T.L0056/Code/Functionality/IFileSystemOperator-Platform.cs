using System;
using System.Collections.Generic;

using R5T.T0221;

using R5T.T0132;


namespace R5T.L0056.Platform
{
    [FunctionalityMarker]
    public partial interface IFileSystemOperator : IFunctionalityMarker,
        L0053.IFileSystemOperator
    {
        public void Copy_Files(IEnumerable<FileCopyPair> fileCopyPairs)
        {
            foreach (var fileCopyPair in fileCopyPairs)
            {
                this.Copy_File(fileCopyPair);
            }
        }

        public void Copy_File(FileCopyPair fileCopyPair)
        {
            this.Copy_File(
                fileCopyPair.SourceFilePath,
                fileCopyPair.DestinationFilePath);
        }
    }
}
