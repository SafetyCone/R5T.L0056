using System;
using System.Collections.Generic;

using R5T.T0132;
using R5T.T0181;


namespace R5T.L0056
{
    [FunctionalityMarker]
    public partial interface IFileOperator : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        private static L0053.IFileOperator _Platform => L0053.FileOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


        public void Write_Lines_Synchronous(
            ITextFilePath textFilePath,
            IEnumerable<string> lines)
        {
            _Platform.Write_Lines_Synchronous(
                textFilePath.Value,
                lines);
        }
    }
}