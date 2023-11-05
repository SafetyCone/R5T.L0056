using System;
using System.Linq;

using R5T.T0132;
using R5T.T0159;
using R5T.T0172;
using R5T.T0172.Extensions;
using R5T.T0180;


namespace R5T.L0056
{
    [FunctionalityMarker]
    public partial interface IDocumentationXmlFilePathOperator : IFunctionalityMarker
    {
        public IDocumentationXmlFilePath Get_DocumentationFilePath_ForAssemblyFilePath(IAssemblyFilePath assemblyFilePath)
        {
            var output = Instances.DocumentationFilePathOperator.Get_DocumentationFilePath_ForAssemblyFilePath(assemblyFilePath.Value)
                .ToDocumentationXmlFilePath();

            return output;
        }

        /// <summary>
        /// Given a directory path, get all child XML file paths, and assume that all XML files are documentation files.
        /// </summary>
        public IDocumentationXmlFilePath[] Get_DocumentationXmlFilePaths_AssumeAllXmls(
            IDirectoryPath directoryPath,
            ITextOutput textOutput)
        {
            textOutput.WriteInformation("Getting documentation file paths in:\n\t{0}",
                directoryPath);
            textOutput.WriteInformation("=> Assume all XML files are documentation files.");

            // Assumes that all XML files in the directory are documentation files.
            var output = Instances.FileSystemOperator.Get_ChildFilePaths(
                directoryPath,
                Instances.FileExtensions.Xml)
                .Select(x => x.Value.ToDocumentationXmlFilePath())
                .ToArray();

            textOutput.WriteInformation("{0} documentation files found.",
                output.Length);

            return output;
        }

        /// <inheritdoc cref="Get_DocumentationXmlFilePaths_AssumeAllXmls(IDirectoryPath, ITextOutput)"/>
        public IDocumentationXmlFilePath[] Get_DocumentationXmlFilePaths_AssumeAllXmls(
            IDirectoryPath directoryPath)
        {
            var textOutput = Instances.TextOutputOperator.Get_New_Null();

            return this.Get_DocumentationXmlFilePaths_AssumeAllXmls(
                directoryPath,
                textOutput);
        }
    }
}
