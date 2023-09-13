using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPlanner.Data.AppContext;
using TravelPlanner.Data.Entities;
using TravelPlanner.Models.ViewModeles.DestinationModels;

namespace TravelPlanner.Services.Services.DestinationServices
{
    public class DestinationService : IDestinationService
    { 
        private readonly TravelPlannerDbContext _context;
        private readonly IMapper _mapper;

        public DestinationService(TravelPlannerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AddDestination(DestinationCreate destination)
        {
             var entity = _mapper.Map<Destination>(destination);
             await _context.AddAsync(entity);
             return await _context.SaveChangesAsync() >0 ;
        }

        public async Task<bool> DeleteDestination(int destinationId)
        {
            var destinationInDb = await _context.Destinations.SingleOrDefaultAsync(x => x.Id == destinationId);
            if (destinationInDb == null) { return false; }

             _context.Destinations.Remove(destinationInDb);
            return await _context.SaveChangesAsync()>0;

        }

       

        public async Task<IEnumerable<DestinationListItem>> GetAllDestinations()
        {
            return await _context.Destinations.Select(d => _mapper.Map<DestinationListItem>(d)).ToListAsync();
        }

        public async Task<DestinationDetail> GetDestination(int Id)
        {
            return _mapper.Map<DestinationDetail>(await _context.Destinations.FindAsync(Id));
        }

        public async Task<bool> UpdateDestination(DestinationEdit destination)
        {
            var destinationInDB = await _context.Destinations.AsNoTracking().SingleOrDefaultAsync(x => x.Id == destination.Id);

            if (destinationInDB == null)
            { return false ; }

            var conversion = _mapper.Map<DestinationEdit, Destination>(destination);
            _context.Destinations.Update(conversion);
            return await _context.SaveChangesAsync()>0;
            

        }
    }
}
