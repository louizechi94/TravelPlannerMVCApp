using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TravelPlanner.Data.AppContext;
using TravelPlanner.Data.Entities;
using TravelPlanner.Models.ViewModeles.ScheduledEventModels;

namespace TravelPlanner.Services.Services.ScheduledEventServices
{
   
    public class ScheduledEventService : IScheduledEventService
    {
        private readonly TravelPlannerDbContext _context;
        private readonly IMapper _mapper;

        public ScheduledEventService(TravelPlannerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AddScheduledEvent(ScheduledEventCreate scheduledEvent)
        {
            var entity = _mapper.Map<ScheduledEvent>(scheduledEvent);
            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0;
        }
        
        public async Task<bool> DeleteScheduledEvent(int scheduledEventId)
        {
            var scheduledEventInDb = await _context.ScheduledEvents.SingleOrDefaultAsync(x => x.Id == scheduledEventId);
            if (scheduledEventInDb == null) { return  false; }

            _context.ScheduledEvents.Remove(scheduledEventInDb);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<ScheduledEventListItem>> GetAllScheduledEvents()
        {
             return await _context.ScheduledEvents.Select(x => _mapper.Map<ScheduledEventListItem>(x)).ToListAsync();
        }

        public async Task<ScheduledEventDetail> GetScheduledEvent(int scheduledEventId)
        {
            return _mapper.Map<ScheduledEventDetail>(await _context.ScheduledEvents.FindAsync(scheduledEventId));
        }

        public async Task<bool> UpdateScheduledEvent(ScheduledEventEdit scheduledEvent)
        {
            var scheduledEvenInDb = await _context.ScheduledEvents.SingleOrDefaultAsync(x => x.Id == scheduledEvent.Id);
            if (scheduledEvenInDb == null) { return false; }

            scheduledEvenInDb.Description = scheduledEvent.Description;
            scheduledEvenInDb.Date= scheduledEvent.Date;
            scheduledEvenInDb.Title = scheduledEvent.Title;
            
            return await _context.SaveChangesAsync()> 0;
        }
    }
}
