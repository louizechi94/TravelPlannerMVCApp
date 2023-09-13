using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPlanner.Data.Entities;
using TravelPlanner.Models.ViewModeles.UserModels;
using TravelPlanner.Models.ViewModeles.ItineraryModels;
using TravelPlanner.Models.ViewModeles.DestinationModels;

namespace TravelPlanner.Models.ViewModeles.TripModels
{
    public class TripDetail
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
       
        public UserListItem UserInfo { get; set; }
        public double Budget { get; set; }
        public int? ItineraryId { get; set; }
        public ItineraryListItem? Itinerary { get; set; }
        public List<DestinationListItem>? Destinations { get; set; }
    }
}
