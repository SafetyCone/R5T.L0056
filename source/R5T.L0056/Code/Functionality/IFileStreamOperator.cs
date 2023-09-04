using System;
using System.IO;

using R5T.T0132;
using R5T.T0180;


namespace R5T.L0056
{
    [FunctionalityMarker]
    public partial interface IFileStreamOperator : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        private static L0053.IFileStreamOperator _Platform => L0053.FileStreamOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


        public FileStream Open_Read(IFilePath filePath)
        {
            return _Platform.Open_Read(filePath.Value);
        }
    }
}
