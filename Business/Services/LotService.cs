using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Business.Validation;
using Data.Entities;
using Data.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Services
{
    public class LotService : ILotService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILotRepository _repository;
        private readonly ILotImageRepository _lotImageRepository;

        public LotService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = unitOfWork.LotRepository;
            _lotImageRepository = unitOfWork.LotImageRepository;
        }

        public async Task<int> AddAsync(InputLotModel model)
        {
            var entity = _mapper.Map<Lot>(model);
            await _repository.AddAsync(entity);
            await _unitOfWork.SaveAsync();
            return entity.Id;
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
            _repository.Update(_mapper.Map<Lot>(model));
            await _unitOfWork.SaveAsync();
        }
    }
}
