using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPlanner.Data.Entities
{
    public class Itinerary
    {
        [Key]
        public int Id { get; set; }
        public List<ScheduledEvent>? ScheduledEvents { get; set; }

    }
}
