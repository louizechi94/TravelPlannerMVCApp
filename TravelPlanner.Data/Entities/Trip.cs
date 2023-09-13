using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace TravelPlanner.Data.Entities
{
    public class Trip
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public int UserId {  get; set; }
        [ForeignKey(nameof(UserId))]
        public User UserInfo { get; set; }
       
        [Required]
        public double Budget { get; set; }
        public int? ItineraryId { get; set; }//  This should assigned in the backround evrytime a trip is created we will create an Itinerary object.
        public Itinerary? Itinerary { get; set; }
        public List<Destination>? Destinations { get; set; }
    }
}
