using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPlanner.Data.Entities;
using TravelPlanner.Models.ViewModeles.TripModels;

namespace TravelPlanner.Models.ViewModeles.UserModels
{
    public class UserDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<TripListItem>? Trips { get; set; }
    }
}
