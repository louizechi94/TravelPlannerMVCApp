using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPlanner.Models.ViewModeles.ItineraryModels;

namespace TravelPlanner.Models.ViewModeles.ScheduledEventModels
{
    public class ScheduledEventListItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime Date { get; set; }
        public ItineraryListItem Itinerary { get; set; }
    }
}
