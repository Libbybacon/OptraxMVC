using AutoMapper;
using OptraxDAL.Models.Admin;
using OptraxMVC.Models.Formatters;

namespace OptraxMVC.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile() { }

        public MappingProfile(IPhoneFormatter phoneFormatter)
        {
            CreateMap<Address, Address>().ForMember(dest => dest.ContactPhone, opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.ContactPhone)
                                                                                                       ? null
                                                                                                       : phoneFormatter.Normalize(src.ContactPhone)));
        }
    }
}
