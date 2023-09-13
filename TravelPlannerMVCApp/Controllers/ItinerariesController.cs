using Microsoft.AspNetCore.Mvc;
using TravelPlanner.Models.ViewModeles.ItineraryModels;
using TravelPlanner.Services.Services.ItineraryServices;

namespace TravelPlannerMVCApp.Controllers
{
    public class ItinerariesController : Controller
    {
        private readonly IItineraryService _itineraryService;
        public ItinerariesController(IItineraryService itineraryService)
        {
            _itineraryService = itineraryService;
        }
        public async Task<IActionResult> Index()
        {
            var itineraries = await _itineraryService.GetAllItineraries();  
            return View(itineraries);
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var itinerary = await _itineraryService.GetItinerary(id);
            return View(itinerary);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var itinerary = await _itineraryService.GetItinerary(id);
            return View(itinerary);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ItineraryEdit itineraryEdit)
        {
            if (ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            if(await _itineraryService.UpdateItinerary(itineraryEdit))
            {
                return RedirectToAction(nameof(Index));
            }
            return View(itineraryEdit);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            var itinerary = await _itineraryService.DeleteItinerary(id.Value);
            return View(itinerary);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var itinerary = await _itineraryService.GetItinerary(id);
            if(await _itineraryService.DeleteItinerary(itinerary.Id))
            { 
                return RedirectToAction(nameof(Index));
            }
            else
             return UnprocessableEntity();
        }
       
    }
}
