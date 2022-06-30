using Business.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IFileService
    {
        /// <summary>
        /// Returns image by url
        /// </summary>
        /// <param name="urlFile"></param>
        /// <returns></returns>
        public Task<FileModel> UploadImageAsync(string urlFile);
    }
}
