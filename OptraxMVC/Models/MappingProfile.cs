using AutoMapper;
using OptraxDAL.Models.Admin;

namespace OptraxMVC.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Address, Address>();
        }
    }
}
