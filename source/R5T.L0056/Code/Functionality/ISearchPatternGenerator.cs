using System;

using R5T.N0003;
using R5T.N0003.Extensions;

using R5T.T0131;
using R5T.T0252;


namespace R5T.L0056
{
    [ValuesMarker]
    public partial interface ISearchPatternGenerator : IValuesMarker
    {
        private static L0053.ISearchPatternGenerator Platform => L0053.SearchPatternGenerator.Instance;


        public ISearchPattern Files_WithExtension(IFileExtension fileExtension)
        {
            return Platform.Files_WithExtension(fileExtension.Value)
                .ToSearchPattern();
        }
    }
}
