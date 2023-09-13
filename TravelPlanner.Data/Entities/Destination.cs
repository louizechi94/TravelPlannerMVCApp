using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPlanner.Data.Entities
{
    public class Destination
    {
        [Required]
        public int Id { get; set; }
       
        [Required]
        public string Location { get; set; }
        [Required]
        public List<Trip>? Trips { get; set; }
    }
}
