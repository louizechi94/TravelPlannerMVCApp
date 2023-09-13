using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPlanner.Models.ViewModeles.DestinationModels
{
    public class DestinationCreate
    {
        
        [Required]
        public string Location { get; set; } = null!;
    }
}
