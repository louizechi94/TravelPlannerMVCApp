using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPlanner.Models.ViewModeles.ScheduledEventModels
{
    public class ScheduledEventCreate
    {
        
        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
        [Required]
        public DateTime Date { get; set; }
        public int ItineraryId { get; set; }
    }
}
