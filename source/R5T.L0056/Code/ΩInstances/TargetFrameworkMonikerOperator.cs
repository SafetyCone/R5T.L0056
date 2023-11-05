using System;


namespace R5T.L0056
{
    public class TargetFrameworkMonikerOperator : ITargetFrameworkMonikerOperator
    {
        #region Infrastructure

        public static ITargetFrameworkMonikerOperator Instance { get; } = new TargetFrameworkMonikerOperator();


        private TargetFrameworkMonikerOperator()
        {
        }

        #endregion
    }
}
