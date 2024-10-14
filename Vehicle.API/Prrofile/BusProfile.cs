using AutoMapper;
using Vehicle.API.Entities;
using Vehicle.API.Models;

namespace Vehicle.API.Prrofile
{
    public class BusProfile : Profile
    {
        public BusProfile()
        {
            CreateMap<Bus, BusDto>();
            CreateMap<BusDto, Bus>();
        }
    }
}
