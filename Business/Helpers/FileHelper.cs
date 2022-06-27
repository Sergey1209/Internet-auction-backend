using Business.Models;
using Business.Validation;
using Microsoft.AspNetCore.Http;
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

        public async Task<string> SaveImage(IFormFile image)
        {
            if (image == null)
                throw new NullModelException("image");

            var fileName = GetFullNameForSaveFile(image.FileName);
            var path = $@"{Directory}\{fileName}";

            using (Stream fileStream = new FileStream(path: path, mode: FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }

            return fileName;
        }


        /// <summary>
        /// Returns file for upload
        /// </summary>
        /// <param name="urlFile"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<FileModel> GetSerializedImageByUrl(string urlFile)
        {
            var path = $"{Directory}\\{urlFile}";
            if (!File.Exists(path))
                throw new Exception("File not found");

            byte[] contentData = await File.ReadAllBytesAsync(path);
            string name = urlFile.Split(@"\").Last();

            return new FileModel() { ContentData = contentData, ContentType = GetContentType(urlFile), Name = name };
        }

        private string GetContentType(string urlFile)
        {
            var imgExt = urlFile.Split('.')?.Last();
            if (imgExt == null)
                throw new Exception("Image has no extension");

            string contentType;
            switch (imgExt)
            {
                case "png":
                case "jpg":
                case "jpeg":
                case "pjpeg":
                case "gif":
                case "tiff":
                    contentType = $"Image/{imgExt}";
                    break;
                default:
                    throw new Exception("Image type is not valid");
            }

            return contentType;
        }
    }
}
