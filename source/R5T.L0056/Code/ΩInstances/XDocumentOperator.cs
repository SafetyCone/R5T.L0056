using System;


namespace R5T.L0056
{
    public class XDocumentOperator : IXDocumentOperator
    {
        #region Infrastructure

        public static IXDocumentOperator Instance { get; } = new XDocumentOperator();


        private XDocumentOperator()
        {
        }

        #endregion
    }
}
