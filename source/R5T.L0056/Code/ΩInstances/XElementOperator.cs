using System;


namespace R5T.L0056
{
    public class XElementOperator : IXElementOperator
    {
        #region Infrastructure

        public static IXElementOperator Instance { get; } = new XElementOperator();


        private XElementOperator()
        {
        }

        #endregion
    }
}
