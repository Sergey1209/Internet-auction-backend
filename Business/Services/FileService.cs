using Business.Helpers;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Business.Services
{
    public class FileService : IFileService
    {
        private readonly HostConfig _hostConfig;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileRepository _repository;
        private readonly FileHelper _imageFileHelper; 

        public FileService(HostConfig hostConfig, IUnitOfWork unitOfWork)
        {
            _hostConfig = hostConfig;
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.FileRepository;
            _imageFileHelper = new FileHelper(_hostConfig.ImagesDirectory);
        }

        public async Task<FileModel> UploadImageAsync(string urlFile)
        {

            byte[] contentData;
            var imgDirectory = _hostConfig.ImagesDirectory;
            string name;

            if (urlFile.Contains(@"//:"))
            {
                using var client = new HttpClient();
                var response = await client.GetAsync(urlFile);
                contentData = await response.Content.ReadAsByteArrayAsync();
                name = urlFile.Split(@"/").Last();
            }
            else
            {
                var path = $"{imgDirectory}\\{urlFile}";
                if (!System.IO.File.Exists(path))
                    throw new Exception("File not found");

                contentData = await System.IO.File.ReadAllBytesAsync(path);
                name = urlFile.Split(@"\").Last();
            }

            return new FileModel() { ContentData = contentData, ContentType = GetContentType(urlFile), Name = name };
        }

        public async Task<int> AddAsync(IFormFile image)
        {
            if (image == null)
                throw new ArgumentNullException("image");

            var fileName = await SaveImage(image);
                
            var fileEntity = new File() { Name = fileName };

            await _repository.AddAsync(fileEntity);
            await _unitOfWork.SaveAsync();
            return await _repository.GetIdByNameAsync(fileEntity.Name);
        }

        public async Task<IEnumerable<int>> AddAsync(IEnumerable<IFormFile> images)
        {
            if (images == null)
                throw new ArgumentNullException("images");

            var ids = new List<int>();
            foreach (var imageEntity in images)
            {
                if (imageEntity == null)
                    throw new NullReferenceException("Image is null");

                var id = await AddAsync(imageEntity);
                if (!ids.Contains(id) && id > 0)
                    ids.Add(id);
            }
            return ids;
        }

        public async Task<string> SaveImage(IFormFile image)
        {
            if (image == null)
                throw new ArgumentNullException("image");

            var fileName = _imageFileHelper.GetFullNameForSaveFile(image.FileName);
            var path = $@"{_imageFileHelper.Directory}\{fileName}";

            using (System.IO.Stream fileStream = new System.IO.FileStream(path: path, mode: System.IO.FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }

            return fileName;
        }

        public async Task UpdateAsync(int id, IFormFile newFile)
        {
            if (newFile == null)
                throw new ArgumentNullException("newFile");

            var dbFile = await _repository.GetByIdAsync(id);

            await _imageFileHelper.RemoveFileAsync(dbFile.Name);

            var newFileName = await SaveImage(newFile);
            dbFile.Name = newFileName;
            _repository.Update(dbFile);

            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(IEnumerable<int> ids)
        {
            foreach (var id in ids)
            {
                if (id > 0)
                {
                    var dbFile = await _repository.GetByIdAsync(id);
                    await _repository.DeleteByIdAsync(id);
                    await _imageFileHelper.RemoveFileAsync(dbFile?.Name);
                }
            }
            await _unitOfWork.SaveAsync();
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
