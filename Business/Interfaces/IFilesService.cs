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

        /// <summary>
        /// Adds images to data source and save to local disk
        /// </summary>
        /// <param name="images"></param>
        /// <returns>Returns file id</returns>
        public Task<IEnumerable<int>> AddAsync(IEnumerable<IFormFile> images);

        /// <summary>
        /// Adds a image to data source and save to local disk
        /// </summary>
        /// <param name="image"></param>
        /// <returns>Returns file id</returns>
        public Task<int> AddAsync(IFormFile image);

        /// <summary>
        /// Updates file data
        /// </summary>
        /// <param name="id">File id</param>
        /// <param name="newFile">New file name</param>
        /// <returns></returns>
        public Task UpdateAsync(int id, IFormFile newFile);

        /// <summary>
        /// Deletes files by this ids
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public Task DeleteAsync(IEnumerable<int> ids);
    }
}
