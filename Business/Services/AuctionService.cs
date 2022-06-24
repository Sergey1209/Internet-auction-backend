using AutoMapper;
using Business.Interfaces;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuctionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
