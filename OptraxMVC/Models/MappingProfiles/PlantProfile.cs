using AutoMapper;
using OptraxDAL.Models.Grow;

namespace OptraxMVC.Models.MappingProfiles
{
    public class PlantProfile : Profile
    {
        public PlantProfile()
        {
            CreateMap<Plant, Plant>().ForMember(newPlant => newPlant.Id, opt => opt.Ignore())
                                     .AfterMap((src, newPlant) =>
                                     {

                                     });
        }
    }

}
