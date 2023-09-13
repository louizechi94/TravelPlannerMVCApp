using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPlanner.Data.AppContext;
using TravelPlanner.Data.Entities;
using TravelPlanner.Models.ViewModeles.ItineraryModels;

namespace TravelPlanner.Services.Services.ItineraryServices
{
    public class ItineraryService : IItineraryService
    {
        private readonly TravelPlannerDbContext _context;
        private readonly IMapper _mapper;

        public ItineraryService(TravelPlannerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> DeleteItinerary(int itineraryId)
        {
            var itineraryInDb = await _context.Itineraries.SingleOrDefaultAsync(x => x.Id == itineraryId);
            if (itineraryInDb == null) { return false; }
             
            _context.Itineraries.Remove(itineraryInDb);
            return await _context.SaveChangesAsync()>0;
        }

        public async Task<IEnumerable<ItineraryListItem>> GetAllItineraries()
        {
            return await _context.Itineraries.Select(i => _mapper.Map<ItineraryListItem>(i)).ToListAsync();
        }

        public async Task<ItineraryDetail> GetItinerary(int Id)
        {
           return _mapper.Map<ItineraryDetail>(await _context.Itineraries.FindAsync(Id));
        }

        public async Task<bool> UpdateItinerary(ItineraryEdit itinerary)
        {
            var itineraryInDb = await _context.Itineraries.AsNoTracking().SingleOrDefaultAsync(x => x.Id == itinerary.Id);
            if(itineraryInDb == null) { return false; }

            var conversion = _mapper.Map<ItineraryEdit, Itinerary>(itinerary);
            _context.Itineraries.Update(conversion);
            return await _context.SaveChangesAsync()>0;




        }
    }
}
