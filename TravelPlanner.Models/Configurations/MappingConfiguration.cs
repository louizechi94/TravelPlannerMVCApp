using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPlanner.Data.Entities;
using TravelPlanner.Models.ViewModeles.DestinationModels;
using TravelPlanner.Models.ViewModeles.ItineraryModels;
using TravelPlanner.Models.ViewModeles.ScheduledEventModels;
using TravelPlanner.Models.ViewModeles.TripModels;
using TravelPlanner.Models.ViewModeles.UserModels;

namespace TravelPlanner.Models.Configurations
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        { 
            CreateMap<User, UserCreate>().ReverseMap();
            CreateMap<User, UserDetail>().ReverseMap();
            CreateMap<User, UserListItem>().ReverseMap();
            CreateMap<User, UserEdit>().ReverseMap();


            CreateMap<Destination, DestinationCreate>().ReverseMap();
            CreateMap<Destination, DestinationDetail>().ReverseMap();
            CreateMap<Destination, DestinationListItem>().ReverseMap();
            CreateMap<Destination, DestinationEdit>().ReverseMap();


            CreateMap<Trip, TripCreate>().ReverseMap();
            CreateMap<Trip, TripDetail>().ReverseMap();
            CreateMap<Trip, TripListItem>().ReverseMap();
            CreateMap<Trip, TripEdit>().ReverseMap();


            CreateMap<Itinerary, ItineraryDetail>().ReverseMap();
            CreateMap<Itinerary, ItineraryListItem>().ReverseMap();
            CreateMap<Itinerary, ItineraryEdit>().ReverseMap();


            CreateMap<ScheduledEvent, ScheduledEventCreate>().ReverseMap();
            CreateMap<ScheduledEvent, ScheduledEventDetail>().ReverseMap();
            CreateMap<ScheduledEvent, ScheduledEventListItem>().ReverseMap();
            CreateMap<ScheduledEvent, ScheduledEventEdit>().ReverseMap();

        }
    }
}
