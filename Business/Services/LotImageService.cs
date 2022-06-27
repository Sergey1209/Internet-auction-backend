using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Services
{
    public class LotImageService : ILotImageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILotImageRepository _repository;
        private readonly IFileService _fileService;

        public LotImageService(IUnitOfWork unitOfWork, IMapper mapper, IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = unitOfWork.LotImageRepository;
            _fileService = fileService;
        }

        public async Task AddAsync(int lotId, IEnumerable<IFormFile> images)
        {
            if (images == null)
                return;

            var newFilesIds = await _fileService.AddAsync(images);
            foreach (var fileId in newFilesIds)
            {
                await _repository.AddAsync(new LotImage() { LotId = lotId, FileId = fileId });
            }

            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteByLotIdAsync(int lotId)
        {
            var models = await _repository.GetByLotIdAsync(lotId);
            var ids = models.Select(x => x.FileId).ToArray();
            await _fileService.DeleteAsync(ids);
        }

        public async Task<IEnumerable<LotImageModel>> GetByLotIdAsync(int lotId)
        {
            var result = await _repository.GetByLotIdAsync(lotId);
            return _mapper.Map<IEnumerable<LotImageModel>>(result);
        }

    }
}
