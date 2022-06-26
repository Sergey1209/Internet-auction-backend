using AutoMapper;
using Business.Helpers;
using Business.Interfaces;
using Business.Models;
using Business.Validation;
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

        public LotCategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = unitOfWork.LotCategoryRepository;
        }

        public async Task AddAsync(LotCategoryModel model)
        {
            ValidateModel(model);
            await _repository.AddAsync(_mapper.Map<LotCategory>(model));
            await _unitOfWork.SaveAsync();
        }

        public async Task AddAsync(string name, int? fileId)
        {
            var model = new LotCategory() { Name = name, FileId = fileId };
            await _repository.AddAsync(model);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int modelId)
        {
            if (modelId == 0)
                return;

            await _repository.DeleteByIdAsync(modelId);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<LotCategoryModel>> GetAllAsync()
        {
            var list = await _repository.GetAllByDetalsAsync();
            var result = _mapper.Map<IEnumerable<LotCategoryModel>>(list.OrderBy(categ => categ.Name));
            return result;
        }

        public async Task<LotCategoryModel> GetByIdAsync(int modelId)
        {
            if (modelId == 0)
                return await new Task<LotCategoryModel>(() => new LotCategoryModel() { });

            var result = await _repository.GetByIdWithDetailsAsync(modelId);
            return _mapper.Map<LotCategoryModel>(result);
        }

        public async Task<int> GetFileId(int lotCategoryId)
        {
            var result = await _repository.GetByIdWithDetailsAsync(lotCategoryId);
            return result.File.Id;
        }

        public async Task UpdateAsyc(LotCategoryModel model)
        {
            ValidateModel(model);
            _repository.Update(_mapper.Map<LotCategory>(model));
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsyc(InputLotCategoryModel inputModel)
        {
            ValidateModel(inputModel);

            var dbLotCategory = await _repository.GetByIdAsync(inputModel.Id);
            dbLotCategory.Name = inputModel.Name;
           
            _repository.Update(dbLotCategory);
            await _unitOfWork.SaveAsync();
        }

        private void ValidateModel(IValidatelyModel model)
        {
            if (model == null)
                throw new NullModelException("The Model is null");

            model.Validate();
        }
    }
}
