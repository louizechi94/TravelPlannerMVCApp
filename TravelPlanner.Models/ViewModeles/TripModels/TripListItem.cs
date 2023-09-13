using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPlanner.Data.Entities;
using TravelPlanner.Models.ViewModeles.UserModels;

namespace TravelPlanner.Models.ViewModeles.TripModels
{
    public class TripListItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
       
    }
}
