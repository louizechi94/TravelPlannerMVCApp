using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPlanner.Data.Entities;
using TravelPlanner.Models.ViewModeles.ItineraryModels;

namespace TravelPlanner.Models.ViewModeles.ScheduledEventModels
{
    public class ScheduledEventDetail
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime Date { get; set; }
        public ItineraryListItem Itinerary { get; set; } = null!;
    }
}
