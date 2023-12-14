using System;
using System.Xml.Linq;

using R5T.L0030.T000;
using R5T.T0132;
using R5T.T0203;


namespace R5T.L0056
{
    [FunctionalityMarker]
    public partial interface IXElementOperator : IFunctionalityMarker
    {
#pragma warning disable IDE1006 // Naming Styles
        public static L0053.IXElementOperator _Platform => L0053.XElementOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


        public XElement Create_Element(IElementName elementName)
        {
            var output = _Platform.Create_Element_FromName(elementName.Value);
            return output;
        }

        /// <summary>
        /// Parses the XML text as it is, without changes.
        /// </summary>
        public XElement Parse_AsIs(IXmlText xmlText)
        {
            var output = _Platform.Parse_AsIs(xmlText.Value);
            return output;
        }
    }
}
