using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IReceiptRepository _repository;

        public ReceiptService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = unitOfWork.ReceiptRepository;
        }

        public async Task AddAsync(ReceiptModel model)
        {
            var entity = _mapper.Map<Receipt>(model);
            await _repository.AddAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<ReceiptModel>> GetAllAsync()
        {
            var items = await _repository.GetAllWithDetailsAsync();
            var result = _mapper.Map<IEnumerable<ReceiptModel>>(items);
            return result;
        }

        public async Task<ReceiptModel> GetByIdAsync(int modelId)
        {
            var result = await _repository.GetByIdWithDetailsAsync(modelId);
            return _mapper.Map<ReceiptModel>(result);
        }
    }
}
