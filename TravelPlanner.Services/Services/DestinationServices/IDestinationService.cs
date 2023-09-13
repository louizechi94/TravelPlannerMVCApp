using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPlanner.Models.ViewModeles.DestinationModels;

namespace TravelPlanner.Services.Services.DestinationServices
{
    public interface IDestinationService
    {
        Task<bool> AddDestination(DestinationCreate destination);
        Task<bool> UpdateDestination(DestinationEdit destination);
        Task<bool> DeleteDestination(int destinationId);
        Task<DestinationDetail> GetDestination(int Id);
        Task<IEnumerable<DestinationListItem>> GetAllDestinations();
    }
}
