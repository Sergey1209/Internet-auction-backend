using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Helpers
{
    /// <summary>
    /// Class for working with files
    /// </summary>
    public class FileHelper
    {
        public string Directory { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="directory">Destination folder</param>
        public FileHelper(string directory)
        {
            Directory = directory;

            if (string.IsNullOrEmpty(Directory))
                throw new InvalidOperationException("This directory is empty");

            if (!System.IO.Directory.Exists(Directory))
                throw new InvalidOperationException("Directory does not exist");
        }

        /// <summary>
        /// Returns a valid filename
        /// </summary>
        /// <param name="fileName">Source file name. The file name must have the extension</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public string GetFullNameForSaveFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new InvalidOperationException("This file is empty");

            fileName = fileName.Replace(@"/\*?|"":<>", "_");

            string path = $@"{Directory}\{fileName}";

            var arr = fileName.Split('.');
            if (arr == null || arr.Length < 2)
                throw new InvalidOperationException("There is no file's extension");

            var ext = arr?.Last();
            var name = string.Join("", arr.Take(arr.Length - 1));
            int i = 0;

            while (File.Exists(path))
            {
                fileName = $"{name}{++i}.{ext}";
                path = $@"{Directory}\{fileName}";
            }

            return fileName;
        }

        /// <summary>
        /// Removing file
        /// </summary>
        /// <param name="fileName">Source file name. The file name must have the extension</param>
        public void RemoveFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) 
                return;

            string path = $@"{Directory}\{fileName}";
            if (File.Exists(path)) File.Delete(path);
        }

        public async Task RemoveFileAsync(string fileName)
        {
            await Task.Factory.StartNew(() => RemoveFile(fileName));
        }
    }
}
