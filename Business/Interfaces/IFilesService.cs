using Business.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IFileService
    {
        public Task<FileModel> UploadImageAsync(string urlFile);
        public Task<IEnumerable<int>> AddAsync(IEnumerable<IFormFile> images);
        public Task<int> AddAsync(IFormFile image);
        public Task<string> SaveImage(IFormFile image);
        public Task UpdateAsync(int id, IFormFile newFile);
        public Task DeleteAsync(IEnumerable<int> ids);
    }
}
