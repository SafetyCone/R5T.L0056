using System;
using System.Threading.Tasks;
using System.Xml.Linq;

using R5T.T0132;
using R5T.T0181;


namespace R5T.L0056
{
    [FunctionalityMarker]
    public partial interface IXDocumentOperator : IFunctionalityMarker,
        L0053.IXDocumentOperator
    {
        public XDocument Load_Synchronous(IXmlFilePath filePath)
        {
            var xDocument = this.Load_Synchronous(filePath.Value);
            return xDocument;
        }

        public Task<XDocument> Load(IXmlFilePath filePath)
        {
            return this.Load(filePath.Value);
        }

        public Task<XDocument> Load(
            IXmlFilePath filePath,
            LoadOptions loadOptions)
        {
            return this.Load(
                filePath.Value,
                loadOptions);
        }
    }
}
