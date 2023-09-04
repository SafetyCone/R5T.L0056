using System;


namespace R5T.L0056
{
    public static class Instances
    {
        public static L0053.IAssemblyFileNameOperator AssemblyFileNameOperator_Platform => L0053.AssemblyFileNameOperator.Instance;
        public static IExecutablePathOperator ExecutablePathOperator => L0056.ExecutablePathOperator.Instance;
        public static IFileExtensions FileExtensions => L0056.FileExtensions.Instance;
        public static IFileNameOperator FileNameOperator => L0056.FileNameOperator.Instance;
        public static L0053.IFileNameOperator FileNameOperator_Platform => L0053.FileNameOperator.Instance;
        public static Extensions.IStringOperator StringOperator_Extensions => Extensions.StringOperator.Instance;
    }
}