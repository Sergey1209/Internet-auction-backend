using AutoMapper;
using Business.Helpers;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Services
{
    public class LotService : ILotService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILotRepository _repository;
        private readonly IFileRepository _fileRepository;
        private readonly ILotImageRepository _lotImageRepository;
        private readonly FileHelper _imageFileHelper;

        public LotService(IUnitOfWork unitOfWork, IMapper mapper, IHostConfig hostConfig)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = unitOfWork.LotRepository;
            _fileRepository = unitOfWork.FileRepository;
            _lotImageRepository = unitOfWork.LotImageRepository;
            _imageFileHelper = new FileHelper(hostConfig.ImagesDirectory);
        }

        public async Task<IEnumerable<LotModel>> GetAllAsync()
        {
            var lots = await _repository.GetAllByDetalsAsync();
            var result = _mapper.Map<IEnumerable<LotModel>>(lots);
            return result;
        }

        public async Task<IEnumerable<LotModel>> GetLastAsync(int count)
        {
            var lots = await _repository.GetLastByDetalsAsync(count);
            var result = _mapper.Map<IEnumerable<LotModel>>(lots);
            return result;
        }

        public async Task<IEnumerable<LotModel>> GetRangeAsync(int id1, int id2)
        {
            var lots = await _repository.GetRangeByDetalsAsync(id1, id2);
            var result = _mapper.Map<IEnumerable<LotModel>>(lots);
            return result;
        }

        public async Task<IEnumerable<LotModel>> GetAllByFilter(string searchString)
        {
            var lots = await _repository.GetAllByFilterAsync(searchString);
            var result = _mapper.Map<IEnumerable<LotModel>>(lots);
            return result;
        }

        public async Task<LotModel> GetByIdAsync(int modelId)
        {
            var result = await _repository.GetByIdWithDetailsAsync(modelId);
            return _mapper.Map<LotModel>(result);
        }

        public async Task AddAsync(InputLotModel inputModel)
        {
            var lot = _mapper.Map<Lot>(inputModel);
            await _repository.AddAsync(lot);

            await SaveImagesOfLot(lot, inputModel.Files);

            var now = DateTime.UtcNow;
            lot.Auction = new Auction()
            {
                LotId = lot.Id,
                Deadline = inputModel.Deadline,
                InitialPrice = inputModel.InitialPrice ?? 0,
                BetValue = inputModel.InitialPrice ?? 0,
                CustomerId = lot.OwnerId,
                OperationDate = now,
                InitialDate = now

            };

            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var lot = await _repository.GetByIdWithDetailsAsync(id);
            await DeleteImagesOfLot(lot.LotImages);
            await _repository.DeleteByIdAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsyc(InputLotModel inputLotModel)
        {
            var lot = await _repository.GetByIdWithDetailsAsync(inputLotModel.Id);
            await DeleteImagesOfLot(lot.LotImages, inputLotModel.NotChangedFiles);
            await SaveImagesOfLot(lot, inputLotModel.Files);

            var now = DateTime.UtcNow;

            lot.Name = inputLotModel.Name;
            lot.CategoryId = inputLotModel.CategoryId;
            lot.Description = inputLotModel.Description;

            lot.Auction.InitialPrice = inputLotModel.InitialPrice ?? 0;
            lot.Auction.BetValue = inputLotModel.InitialPrice ?? 0;
            lot.Auction.Deadline = inputLotModel.Deadline;
            lot.Auction.OperationDate = now;
            lot.Auction.InitialDate = now;
            lot.Auction.CustomerId = lot.OwnerId;

            _repository.Update(lot);

            await _unitOfWork.SaveAsync();
        }

        private async Task DeleteImagesOfLot(IEnumerable<LotImage> lotImages, IEnumerable<string> NotChangedFiles = null)
        {
            if (lotImages == null) return;

            foreach (var lotImage in lotImages)
            {
                if (lotImage != null && lotImage.File != null && !NotChangedFiles.Contains(lotImage.File.Name))
                {
                    await _imageFileHelper.RemoveFileAsync(lotImage.File.Name);
                    await _fileRepository.DeleteByIdAsync(lotImage.FileId);
                }
            }
        }

        private async Task SaveImagesOfLot(Lot lot, IEnumerable<IFormFile> files)
        {
            if (files == null) return;

            foreach (var image in files)
            {
                if (image != null)
                {
                    var fileName = await _imageFileHelper.SaveImage(image);
                    var file = new File() { Name = fileName };
                    await _lotImageRepository.AddAsync(new LotImage() { Lot = lot, File = file });
                }
            }
        }
    }
}
