using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPlanner.Models.ViewModeles.DestinationModels
{
    public class DestinationListItem
    {
        public int Id { get; set; }
        public string Location { get; set; } = null!;
    }
}
