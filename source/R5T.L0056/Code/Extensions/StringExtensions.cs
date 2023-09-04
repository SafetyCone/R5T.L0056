using System;


namespace R5T.L0056.Extensions
{
    public static class StringExtensions
    {
        /// <inheritdoc cref="IStringOperator.ToExecutableFilePath(string)"/>
        public static IExecutableFilePath ToExecutableFilePath(this string value)
        {
            return Instances.StringOperator_Extensions.ToExecutableFilePath(value);
        }
    }
}
