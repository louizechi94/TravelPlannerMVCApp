using Microsoft.AspNetCore.Mvc;
using TravelPlanner.Models.ViewModeles.DestinationModels;
using TravelPlanner.Services.Services.DestinationServices;

namespace TravelPlannerMVCApp.Controllers
{
    public class DestinationsController : Controller
    {
        private readonly IDestinationService _destinationService;
        public DestinationsController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var destinations = await _destinationService.GetAllDestinations();
            return View(destinations);
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var destination = await _destinationService.GetDestination(id);
            return View(destination);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DestinationCreate destinationCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _destinationService.AddDestination(destinationCreate))
            {
                return RedirectToAction(nameof(Index));
            }
            return View(destinationCreate);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var destination = await _destinationService.GetDestination(id);
            return View(destination);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DestinationEdit destinationEdit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _destinationService.UpdateDestination(destinationEdit))
            {
                return RedirectToAction(nameof(Index));
            }
            return View(destinationEdit);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)

        {
            var destination = await _destinationService.GetDestination(id.Value);
            return View(destination);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var destination = await _destinationService.GetDestination(id);
            if(await _destinationService.DeleteDestination(destination.Id)) 
            {
            return RedirectToAction(nameof(Index));
            }
            else 
                return UnprocessableEntity();
        }

    }
}

