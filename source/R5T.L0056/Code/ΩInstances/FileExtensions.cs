using System;


namespace R5T.L0056
{
    public class FileExtensions : IFileExtensions
    {
        #region Infrastructure

        public static IFileExtensions Instance { get; } = new FileExtensions();


        private FileExtensions()
        {
        }

        #endregion
    }
}
