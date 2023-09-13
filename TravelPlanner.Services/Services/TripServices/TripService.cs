using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPlanner.Data.AppContext;
using TravelPlanner.Data.Entities;
using TravelPlanner.Models.ViewModeles.TripModels;
using TravelPlanner.Services.Services.ItineraryServices;

namespace TravelPlanner.Services.Services.TripServices
{
    public class TripService : ITripService
    {   
        private readonly TravelPlannerDbContext _context;
        private readonly IMapper _mapper;
        private readonly IItineraryService  _itineraryService;
        public TripService(TravelPlannerDbContext context, IMapper mapper, IItineraryService itineraryService)
        {
            _context = context;
            _mapper = mapper;
            _itineraryService = itineraryService;
        }

        public async Task<bool> AddTrip(TripCreate trip)
        {
            var entity = _mapper.Map<Trip>(trip);
            await _context.Trips.AddAsync(entity);
            //create a new itinerary
            var itinerary = new Itinerary();
            await _context.Itineraries.AddAsync(itinerary);
            entity.Itinerary = itinerary;
            

            return await _context.SaveChangesAsync()>0;   
        }

        public async Task<bool> DeleteTrip(int id)
        {
            var tripInDb = await _context.Trips.SingleOrDefaultAsync(x => x.Id == id);
            if (tripInDb == null) { return false; }
           int itineraryId = tripInDb.ItineraryId.Value;
            _context.Trips.Remove(tripInDb);
           await _itineraryService.DeleteItinerary(itineraryId);
             await _context.SaveChangesAsync()  ;
            return true;
        }

        public async Task<TripDetail> GetTrip(int tripId)
        {
           return _mapper.Map<TripDetail>(await _context.Trips.FindAsync( tripId));
        }

        public async Task<IEnumerable<TripListItem>> GetTrips()
        {
            return await _context.Trips.Select(t => _mapper.Map<TripListItem>(t)).ToArrayAsync();
        }

        public async Task<bool> UpdateTrip(TripEdit trip)
        {
            var tripInDb = await _context.Trips.SingleOrDefaultAsync(x => x.Id == trip.Id);
            if (tripInDb == null)
            {  return false; }

           tripInDb.StartDate = trip.StartDate;
            tripInDb.EndDate = trip.EndDate;
            tripInDb.Budget = trip.Budget;
            tripInDb.Title = trip.Title;
             await _context.SaveChangesAsync()  ;
            return true;

        }
    }
}
