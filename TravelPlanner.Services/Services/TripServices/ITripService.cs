using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPlanner.Models.ViewModeles.TripModels;

namespace TravelPlanner.Services.Services.TripServices
{
    public interface ITripService
    {
        Task<bool> AddTrip(TripCreate trip);
        Task<bool> UpdateTrip(TripEdit trip);
        Task<bool> DeleteTrip(int id);
        Task<TripDetail> GetTrip(int tripId);
        Task<IEnumerable<TripListItem>> GetTrips();

    }
}
