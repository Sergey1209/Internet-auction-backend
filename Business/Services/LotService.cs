using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Business.Validation;
using Data.Entities;
using Data.Interfaces;
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
        public LotService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = unitOfWork.LotRepository;
        }

        public async Task<int> AddAsync(InputLotModel model)
        {
            ValidateModel(model);
            await _repository.AddAsync(_mapper.Map<Lot>(model));
            await _unitOfWork.SaveAsync();

            var lot = _mapper.Map<Lot>(model);
            var lots = await _repository.GetIdAsync(lot);

            var result = lots?.Count() > 0 ? lots.Max(x => x.Id) : 0;
            return result;
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteByIdAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<LotModel>> GetAllAsync()
        {
            var lots = await _repository.GetAllByDetalsAsync();
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

        public async Task UpdateAsyc(InputLotModel model)
        {
            ValidateModel(model);
            _repository.Update(_mapper.Map<Lot>(model));
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
