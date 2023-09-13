using Microsoft.AspNetCore.Mvc;
using TravelPlanner.Data.Entities;
using TravelPlanner.Models.ViewModeles.ScheduledEventModels;
using TravelPlanner.Models.ViewModeles.UserModels;
using TravelPlanner.Services.Services.ScheduledEventServices;

namespace TravelPlannerMVCApp.Controllers
{
    public class ScheduledEventsController : Controller
    {
        private readonly IScheduledEventService _scheduledEventService;
        public ScheduledEventsController(IScheduledEventService scheduledEventService)
        {
            _scheduledEventService = scheduledEventService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var scheduledEvents = await _scheduledEventService.GetAllScheduledEvents();
            return View(scheduledEvents);
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var scheduledEvent = await _scheduledEventService.GetScheduledEvent(id);
            return View(scheduledEvent);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ScheduledEventCreate scheduledEventCreate)
        {
            if (!ModelState.IsValid)
            {
                return View(ModelState);
            }
            if (await _scheduledEventService.AddScheduledEvent(scheduledEventCreate))
            {
                return RedirectToAction(nameof(Index));
            }

            return View(scheduledEventCreate);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var scheduledEvent = await _scheduledEventService.GetScheduledEvent(id);
            return View(scheduledEvent);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ScheduledEventEdit scheduledEventEdit)
        {
            if (!ModelState.IsValid)
            {
                return View(ModelState);
            }
            if (await _scheduledEventService.UpdateScheduledEvent(scheduledEventEdit))
            {
                return RedirectToAction(nameof(Index));
            }
            return View(scheduledEventEdit);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            var scheduledEvent = await _scheduledEventService.GetScheduledEvent(id.Value);
            return View(scheduledEvent);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var scheduledEvent = await _scheduledEventService.GetScheduledEvent(id);
            if (await _scheduledEventService.DeleteScheduledEvent(scheduledEvent.Id))
            {
                return RedirectToAction(nameof(Index));
            }
            else
                return UnprocessableEntity();
        }

    }
}
