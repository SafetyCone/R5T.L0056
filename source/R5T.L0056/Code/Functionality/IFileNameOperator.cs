using System;

using R5T.T0132;
using R5T.T0180;
using R5T.T0252;


namespace R5T.L0056
{
    [FunctionalityMarker]
    public partial interface IFileNameOperator : IFunctionalityMarker
    {
        public TFileName Get_FileName<TFileName>(
            IFileNameStem fileNameStem,
            IFileExtension fileExtension,
            Func<string, TFileName> constructor)
        {
            var value = Instances.FileNameOperator_Platform.Get_FileName(
                fileNameStem.Value,
                fileExtension.Value);

            var output = constructor(value);
            return output;
        }

        public IFileName Get_FileName(
            IFileNameStem fileNameStem,
            IFileExtension fileExtension)
        {
            return this.Get_FileName(
                fileNameStem,
                fileExtension,
                T0180.Extensions.StringExtensions.ToFileName);
        }
    }
}
