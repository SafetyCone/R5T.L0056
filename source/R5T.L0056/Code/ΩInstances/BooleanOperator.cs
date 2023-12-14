using System;


namespace R5T.L0056
{
    public class BooleanOperator : IBooleanOperator
    {
        #region Infrastructure

        public static IBooleanOperator Instance { get; } = new BooleanOperator();


        private BooleanOperator()
        {
        }

        #endregion
    }
}
