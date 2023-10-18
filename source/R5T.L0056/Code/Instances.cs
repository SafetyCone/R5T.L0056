using System;


namespace R5T.L0056
{
    public static class Instances
    {
        public static L0053.IAssemblyFileNameOperator AssemblyFileNameOperator_Platform => L0053.AssemblyFileNameOperator.Instance;
        public static L0053.IDocumentationFilePathOperator DocumentationFilePathOperator => L0053.DocumentationFilePathOperator.Instance;
        public static T0221.IElementTypeRelationshipOperator ElementTypeRelationshipOperator => T0221.ElementTypeRelationshipOperator.Instance;
        public static L0053.IExceptionOperator ExceptionOperator => L0053.ExceptionOperator.Instance;
        public static IExecutablePathOperator ExecutablePathOperator => L0056.ExecutablePathOperator.Instance;
        public static IFileExtensions FileExtensions => L0056.FileExtensions.Instance;
        public static IFileNameOperator FileNameOperator => L0056.FileNameOperator.Instance;
        public static L0053.IFileNameOperator FileNameOperator_Platform => L0053.FileNameOperator.Instance;
        public static IFileSystemOperator FileSystemOperator => L0056.FileSystemOperator.Instance;
        public static L0053.IFlagsOperator FlagsOperator => L0053.FlagsOperator.Instance;
        public static L0053.IPredicateOperator PredicateOperator => L0053.PredicateOperator.Instance;
        public static ISearchPatternGenerator SearchPatternGenerator => L0056.SearchPatternGenerator.Instance;
        public static Extensions.IStringOperator StringOperator_Extensions => Extensions.StringOperator.Instance;
        public static T0159.ITextOutputOperator TextOutputOperator => T0159.TextOutputOperator.Instance;
        public static T0179.ITypedOperator TypedOperator => T0179.TypedOperator.Instance;
        public static L0053.ITypeNameAffixes TypeNameAffixes => L0053.TypeNameAffixes.Instance;
    }
}