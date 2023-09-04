using System;

using R5T.T0131;
using R5T.T0180;


namespace R5T.L0056
{
    [ValuesMarker]
    public partial interface IFileExtensions : IValuesMarker,
        Z0010.IFileExtensions
    {
        /// <inheritdoc cref="Z0010.IFileExtensions.Dll"/>
        public IFileExtension Assembly => this.Dll;
    }
}
