using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Business.Validation;
using Data.Interfaces;
using System;
using System.Threading.Tasks;

namespace Business.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly IUnitOfWork _unitOfWorkAuction;
        private readonly IAuctionRepository _auctionRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public AuctionService(IMapper mapper, IUnitOfWork unitOfWork, IUnitOfWorkAuth unitOfWorkAuth)
        {
            _unitOfWorkAuction = unitOfWork;
            _auctionRepository = unitOfWork.AuctionRepository;
            _personRepository = unitOfWorkAuth.PersonRepository;
            _mapper = mapper;
        }

        public async Task MakeBetAsync(int id, decimal betValue, int customerId)
        {
            var auction = await _auctionRepository.GetByIdWithDetailsAsync(id);
            if (auction == null)
                throw new NullReferenceException("Auction is null");

            var now = DateTime.UtcNow;
            if (now < auction.Deadline && betValue > auction.BetValue)
            {
                auction.BetValue = betValue;
                auction.OperationDate = now;
                auction.CustomerId = customerId;
                await _unitOfWorkAuction.SaveAsync();
            }
            else
                throw new BetException("Bet is invalid");
        }

        /// <summary>
        /// Returns the current bet value
        /// </summary>
        /// <param name="lotId"></param>
        /// <returns></returns>
        public async Task<AuctionModel> GetByIdAsync(int id)
        {
            var auction = await _auctionRepository.GetByIdWithDetailsAsync(id);
            var lotModel = _mapper.Map<LotModel>(auction.Lot);
            var customer = await _personRepository.GetByIdAsync(auction.CustomerId);

            return new AuctionModel()
            {
                LotId = auction.Lot.Id,
                OwnerId = auction.Lot.OwnerId,
                CustomerNickname = customer.Nickname,
                BetValue = auction.BetValue,
                Deadline = auction.Deadline ?? DateTime.MinValue,
                LotName = auction.Lot.Name,
                LotDescription = auction.Lot.Description,
                LotImages = lotModel.Images
            };

        }

        public async Task<AuctionModel> GetBetValueByIdAsync(int id)
        {
            var auction = await _auctionRepository.GetByIdWithDetailsAsync(id);
            var customer = await _personRepository.GetByIdAsync(auction.CustomerId);
            return new AuctionModel()
            {
                CustomerNickname = customer.Nickname,
                BetValue = auction.BetValue
            };
        }

    }
}
