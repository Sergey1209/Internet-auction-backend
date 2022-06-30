using Business.Helpers;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;
using System.Threading.Tasks;

namespace Business.Services
{
    public class FileService : IFileService
    {
        private readonly FileHelper _imageFileHelper;

        public FileService(IHostConfig hostConfig, IUnitOfWork unitOfWork)
        {
            _imageFileHelper = new FileHelper(hostConfig.ImagesDirectory);
        }

        public async Task<FileModel> UploadImageAsync(string urlFile)
        {
            return await _imageFileHelper.GetSerializedImageByUrl(urlFile);
        }
    }
}
