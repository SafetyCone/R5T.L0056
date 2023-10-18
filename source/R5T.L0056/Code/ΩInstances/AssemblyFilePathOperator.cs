using System;


namespace R5T.L0056
{
    public class AssemblyFilePathOperator : IAssemblyFilePathOperator
    {
        #region Infrastructure

        public static IAssemblyFilePathOperator Instance { get; } = new AssemblyFilePathOperator();


        private AssemblyFilePathOperator()
        {
        }

        #endregion
    }
}
