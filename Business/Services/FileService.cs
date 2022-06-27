using Business.Helpers;
using Business.Interfaces;
using Business.Models;
using Business.Validation;
using Data.Entities;
using Data.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services
{
    public class FileService : IFileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileRepository _repository;
        private readonly FileHelper _imageFileHelper;

        public FileService(IHostConfig hostConfig, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.FileRepository;
            _imageFileHelper = new FileHelper(hostConfig.ImagesDirectory);
        }

        public async Task<FileModel> UploadImageAsync(string urlFile)
        {
            return await _imageFileHelper.GetSerializedImageByUrl(urlFile);
        }

        public async Task<int> AddAsync(IFormFile image)
        {
            var fileName = await _imageFileHelper.SaveImage(image);

            var fileEntity = new File() { Name = fileName };

            await _repository.AddAsync(fileEntity);
            await _unitOfWork.SaveAsync();
            return fileEntity.Id;
        }

        public async Task<IEnumerable<int>> AddAsync(IEnumerable<IFormFile> images)
        {
            if (images == null)
                throw new NullModelException("images");

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

        public async Task UpdateAsync(int id, IFormFile newFile)
        {
            if (newFile == null)
                throw new NullModelException("newFile");

            var dbFile = await _repository.GetByIdAsync(id);

            await _imageFileHelper.RemoveFileAsync(dbFile.Name);
            var newFileName = await _imageFileHelper.SaveImage(newFile);

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
    }
}
