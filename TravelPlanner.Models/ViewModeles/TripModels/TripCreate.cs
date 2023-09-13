using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPlanner.Data.Entities;

namespace TravelPlanner.Models.ViewModeles.TripModels
{
    public class TripCreate
    {

        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public double Budget { get; set; }
        [Required]
        public int? ItineraryId { get; set; }


    }
}
