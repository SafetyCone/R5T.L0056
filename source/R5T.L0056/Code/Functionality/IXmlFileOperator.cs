using System;
using System.Threading.Tasks;
using System.Xml.Linq;

using R5T.L0089.T000;
using R5T.T0132;
using R5T.T0180;


namespace R5T.L0056
{
    [FunctionalityMarker]
    public partial interface IXmlFileOperator : IFunctionalityMarker
    {
        /// <summary>
        /// Examines the contents of a file path to determine whether the file contains XML.
        /// </summary>
        /// <remarks>
        /// Returns an <see cref="XDocument"/>, since the only way to reliably determine if a file is an XML file is to parse it.
        /// </remarks>
        public async Task<WasFound<XDocument>> Is_XmlFile(IFilePath filePath)
        {
            try
            {
                var document = await Instances.XDocumentOperator.Load(filePath.Value);

                return WasFound.Found(document);
            }
            catch
            {
                return WasFound.NotFound<XDocument>();
            }
        }

        /// <inheritdoc cref="Is_XmlFile(IFilePath)"/>
        public WasFound<XDocument> Is_XmlFile_Synchronous(IFilePath filePath)
        {
            try
            {
                var document = Instances.XDocumentOperator.Load_Synchronous(filePath.Value);

                return WasFound.Found(document);
            }
            catch
            {
                return WasFound.NotFound<XDocument>();
            }
        }
    }
}
