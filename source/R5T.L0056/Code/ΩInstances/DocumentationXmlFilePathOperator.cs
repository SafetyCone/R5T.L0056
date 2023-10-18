using System;


namespace R5T.L0056
{
    public class DocumentationXmlFilePathOperator : IDocumentationXmlFilePathOperator
    {
        #region Infrastructure

        public static IDocumentationXmlFilePathOperator Instance { get; } = new DocumentationXmlFilePathOperator();


        private DocumentationXmlFilePathOperator()
        {
        }

        #endregion
    }
}
