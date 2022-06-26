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
                .ForMember(lm => lm.Images, l => l.MapFrom(x => x.LotImages.Select(y => BuildImagePath(y.File.Name))));
            CreateMap<LotModel, Lot>();

            CreateMap<InputLotModel, Lot>();
            CreateMap<Lot, InputLotModel>();

            CreateMap<LotImage, LotImageModel>();
            CreateMap<LotImageModel, LotImage>();

            CreateMap<PersonAuthModel, PersonAuth>();

            CreateMap<PersonAuthModel, Person>()
                .ForMember(p => p.Id, x => x.MapFrom(pm => pm.PersonId));

            CreateMap<RegistrationModel, Person>();

            CreateMap<RegistrationModel, PersonAuth>();

            CreateMap<LoginModel, PersonAuth>();

            CreateMap<File, FileModel>();

            CreateMap<Receipt, ReceiptModel>();
            CreateMap<ReceiptModel, Receipt>();

        }

        private string BuildImagePath(string path)
        {
            return $@"{_hostConfig.GetBaseUrlForUploadImages()}\{path}".Replace(@"\",@"/");
        }

    }
}
