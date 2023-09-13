using Microsoft.AspNetCore.Mvc;
using TravelPlanner.Models.ViewModeles.TripModels;
using TravelPlanner.Services.Services.TripServices;

namespace TravelPlannerMVCApp.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripService _tripservice;

        public TripsController(ITripService tripservice)
        {
            _tripservice = tripservice;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var trips = await _tripservice.GetTrips();
            return View(trips);
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var trip = await _tripservice.GetTrip(id);
            return View(trip);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TripCreate tripCreate)
        {
            if (ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            if(await _tripservice.AddTrip(tripCreate))
            {
                return RedirectToAction(nameof(Index));
            }
            return View(tripCreate);
                    
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var trip = await _tripservice.GetTrip(id);
            var tEdit = new TripEdit {
                Id = trip.Id,
                Title = trip.Title,
                StartDate = trip.StartDate,
                EndDate= trip.EndDate,
                Budget = trip.Budget,
                
            };
            return View(tEdit);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TripEdit tripEdit)
        {
            if (!ModelState.IsValid) 
            {
            return BadRequest(ModelState);
            }
            if(await _tripservice.UpdateTrip(tripEdit))
            {
                return RedirectToAction(nameof(Index));
            }
            return View(tripEdit);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        { 
            var trip = await _tripservice.GetTrip(id.Value);
            return View(trip);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var trip = await _tripservice.GetTrip(id);
            if(await _tripservice.DeleteTrip(trip.Id))
            {
                return RedirectToAction(nameof(Index));
            }
            else 
                return UnprocessableEntity();   
                

                
        }
            
    }
}
