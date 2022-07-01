using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using System.Linq;

namespace Business
{
    public class AutomapperProfile : Profile
    {
        private readonly IHostConfig _hostConfig;

        public AutomapperProfile(IHostConfig hostConfig)
        {
            _hostConfig = hostConfig;
            CreateMaps();
        }

        private void CreateMaps()
        {
            CreateMap<LotCategory, LotCategoryModel>()
                .ForMember(cm => cm.UrlIcon, c => c.MapFrom(x => BuildImagePath(x.File.Name)));

            CreateMap<Lot, LotModel>()
                .ForMember(lm => lm.Images, l => l.MapFrom(x => x.LotImages.Select(y => BuildImagePath(y.File.Name))))
                .ForMember(lm => lm.Deadline, l => l.MapFrom(x => x.Auction.Deadline))
                .ForMember(lm => lm.BetValue, l => l.MapFrom(x => x.Auction.BetValue))
                .ForMember(lm => lm.InitialPrice, l => l.MapFrom(x => x.Auction.InitialPrice))
                .ForMember(lm => lm.InitialDate, l => l.MapFrom(x => x.Auction.InitialDate))
                .ForMember(lm => lm.AuctionId, l => l.MapFrom(x => x.Auction.Id));

            CreateMap<InputLotModel, Lot>();

            CreateMap<InputLotCategoryModel, LotCategory>();

            CreateMap<PersonModel, PersonAuth>();

            CreateMap<PersonModel, Person>()
                .ForMember(p => p.Id, x => x.MapFrom(pm => pm.PersonId));

            CreateMap<RegistrationModel, Person>();

            CreateMap<RegistrationModel, PersonAuth>();

            CreateMap<LoginModel, PersonAuth>();

            CreateMap<File, FileModel>();

        }

        private string BuildImagePath(string path)
        {
            return $@"{_hostConfig.GetBaseUrlForUploadImages()}\{path}".Replace(@"\", @"/");
        }

    }
}
