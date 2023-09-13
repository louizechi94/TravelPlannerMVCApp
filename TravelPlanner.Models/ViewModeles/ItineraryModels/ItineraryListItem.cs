using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPlanner.Data.Entities;

namespace TravelPlanner.Models.ViewModeles.ItineraryModels
{
    public class ItineraryListItem
    {
        public int Id { get; set; }
        public List<ScheduledEvent>? ScheduledEvents { get; set; }
    }
}
