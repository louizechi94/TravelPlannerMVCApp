using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPlanner.Models.ViewModeles.ScheduledEventModels;

namespace TravelPlanner.Services.Services.ScheduledEventServices
{
    public interface IScheduledEventService
    {
        Task<bool> AddScheduledEvent(ScheduledEventCreate scheduledEvent);
        Task<bool> UpdateScheduledEvent(ScheduledEventEdit scheduledEvent);
        Task<bool> DeleteScheduledEvent(int scheduledEventId);
        Task<ScheduledEventDetail> GetScheduledEvent(int scheduledEventId);
        Task<IEnumerable<ScheduledEventListItem>> GetAllScheduledEvents();
    }
}
