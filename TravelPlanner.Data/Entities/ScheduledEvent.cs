using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPlanner.Data.Entities
{
    public class ScheduledEvent
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        public DateTime Date { get; set; }
        public int ItineraryId { get; set; }
        [ForeignKey(nameof(ItineraryId))]
        public Itinerary Itinerary  { get; set; }= null!;
    }
}
