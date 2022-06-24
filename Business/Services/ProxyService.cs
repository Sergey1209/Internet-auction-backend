using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Business.Validation;
using Data.Entities;
using Data.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ProxyService<TEntity, TModel> where TEntity: BaseEntity where TModel : IValidatelyModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRepository<TEntity> _repository;

        public ProxyService(IUnitOfWork unitOfWork, IMapper mapper, IRepository<TEntity> repository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task AddAsync(TModel model)
        {
            ValidateModel(model);
            await _repository.AddAsync(_mapper.Map<TEntity>(model));
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int modelId)
        {
            await _repository.DeleteByIdAsync(modelId);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<TModel>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<TModel>>(list);
            return result;
        }

        public async Task<TModel> GetByIdAsync(int modelId)
        {
            var result = await _repository.GetByIdAsync(modelId);
            return _mapper.Map<TModel>(result);
        }

        public async Task UpdateAsyc(TModel model)
        {
            ValidateModel(model);
            _repository.Update(_mapper.Map<TEntity>(model));
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
