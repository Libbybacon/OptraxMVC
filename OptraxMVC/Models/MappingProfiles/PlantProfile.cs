using AutoMapper;
using OptraxDAL.Models.Grow;
using OptraxDAL.Models.Inventory;

namespace OptraxMVC.Models.MappingProfiles
{
    public class PlantProfile : Profile
    {
        public PlantProfile()
        {
            CreateMap<Plant, Plant>().ForMember(newPlant => newPlant.ID, opt => opt.Ignore())
                                     .ForMember(newPlant => newPlant.PlantEvents, opt => opt.Ignore())
                                     .ForMember(newPlant => newPlant.NeedsTransferApproval, opt => opt.MapFrom(src => true))
                                     .AfterMap((src, newPlant) =>
                                     {
                                         var newEvent = src.PlantEvents.OfType<TransferEvent>().FirstOrDefault();
                                         if (newEvent != null)
                                         {
                                             newPlant.PlantEvents.Add(new TransferEvent
                                             {
                                                 Date = newEvent.Date,
                                                 EventType = newEvent.EventType,
                                                 UserID = newEvent.UserID,
                                                 Transfer = newEvent.Transfer.NewTransfer(newPlant)
                                             });
                                         }
                                     });
        }
    }

}
