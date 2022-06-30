using AutoMapper;
using Business.Helpers;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
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

        public async Task<IEnumerable<LotModel>> GetAllByFilter(string searchString)
        {
            var lots = await _repository.GetAllByFilterAsync(searchString);
            var result = _mapper.Map<IEnumerable<LotModel>>(lots);
            return result;
        }

        public async Task<IEnumerable<LotModel>> GetAllByCategoryIdAsync(int categoryId)
        {
            if (categoryId == 0)
                return await new Task<IEnumerable<LotModel>>(() => new LotModel[] { });

            var lots = await _repository.GetAllByDetalsByCategoryIdAsync(categoryId);
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

            lot.Auction = new Auction()
            {
                LotId = lot.Id,
                Deadline = inputModel.Deadline,
                InitialPrice = inputModel.InitialPrice ?? 0,
                BetValue = inputModel.InitialPrice ?? 0,
                CustomerId = lot.OwnerId,
                OperationDate = System.DateTime.UtcNow
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

        public async Task UpdateAsyc(InputLotModel model)
        {
            var lot = await _repository.GetByIdWithDetailsAsync(model.Id);
            await DeleteImagesOfLot(lot.LotImages);
            await SaveImagesOfLot(lot, model.Files);

            lot.Auction.InitialPrice = model.InitialPrice ?? 0;
            lot.Auction.BetValue = model.InitialPrice ?? 0;
            lot.Auction.Deadline = model.Deadline;
            lot.Auction.OperationDate = System.DateTime.UtcNow;
            lot.Auction.CustomerId = lot.OwnerId;

            _repository.Update(lot);

            await _unitOfWork.SaveAsync();
        }

        private async Task DeleteImagesOfLot(IEnumerable<LotImage> lotImages)
        {
            if (lotImages == null) return;

            foreach (var lotImage in lotImages)
            {
                await _imageFileHelper.RemoveFileAsync(lotImage.File.Name);
                await _fileRepository.DeleteByIdAsync(lotImage.FileId);
            }
        }

        private async Task SaveImagesOfLot(Lot lot, IEnumerable<IFormFile> files)
        {
            if (files == null) return;

            foreach (var image in files)
            {
                var fileName = await _imageFileHelper.SaveImage(image);
                var file = new File() { Name = fileName };
                await _lotImageRepository.AddAsync(new LotImage() { Lot = lot, File = file });
            }
        }
    }
}
