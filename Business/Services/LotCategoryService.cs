using AutoMapper;
using Business.Helpers;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Services
{
    public class LotCategoryService : ILotCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILotCategoryRepository _repository;
        private readonly FileHelper _imageFileHelper;

        public LotCategoryService(IUnitOfWork unitOfWork, IMapper mapper, IHostConfig hostConfig)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = unitOfWork.LotCategoryRepository;
            _imageFileHelper = new FileHelper(hostConfig.ImagesDirectory);
        }

        public async Task<IEnumerable<LotCategoryModel>> GetAllAsync()
        {
            var list = await _repository.GetAllByDetalsAsync();
            var result = _mapper.Map<IEnumerable<LotCategoryModel>>(list.OrderBy(categ => categ.Name));
            return result;
        }

        public async Task<LotCategoryModel> GetByIdAsync(int id)
        {
            if (id == 0)
                return await new Task<LotCategoryModel>(() => new LotCategoryModel() { });

            var result = await _repository.GetByIdWithDetailsAsync(id);
            return _mapper.Map<LotCategoryModel>(result);
        }

        public async Task AddAsync(InputLotCategoryModel inputLotCategoryModel)
        {
            var fileName = await _imageFileHelper.SaveImage(inputLotCategoryModel.File);

            var lotCategory = new LotCategory()
            {
                Name = inputLotCategoryModel.Name,
                File = new File() { Name = fileName }
            };

            await _repository.AddAsync(lotCategory);

            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsyc(InputLotCategoryModel inputLotCategoryModel)
        {
            var dbLotCategory = await _repository.GetByIdWithDetailsAsync(inputLotCategoryModel.Id);

            await _imageFileHelper.RemoveFileAsync(dbLotCategory.Name);
            string newImage;
            if (inputLotCategoryModel.File != null)
            {
                newImage = await _imageFileHelper.SaveImage(inputLotCategoryModel.File);
                dbLotCategory.File.Name = newImage;
            }

            dbLotCategory.Name = inputLotCategoryModel.Name;
            _repository.Update(dbLotCategory);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id == 0) return;
            await _repository.DeleteByIdAsync(id);
            await _unitOfWork.SaveAsync();
        }

    }
}
