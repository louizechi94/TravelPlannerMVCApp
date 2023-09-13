using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPlanner.Models.ViewModeles.ItineraryModels;

namespace TravelPlanner.Services.Services.ItineraryServices
{
    public interface IItineraryService
    {
        Task<bool> UpdateItinerary(ItineraryEdit itinerary);
        Task<bool> DeleteItinerary(int Id);
        Task<ItineraryDetail> GetItinerary(int Id);
        Task<IEnumerable<ItineraryListItem>> GetAllItineraries();
    }
}
