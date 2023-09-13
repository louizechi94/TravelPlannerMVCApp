using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPlanner.Data.Entities;

namespace TravelPlanner.Models.ViewModeles.DestinationModels
{
    public class DestinationDetail
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public List<Trip>? Trips { get; set; }
    }
}
