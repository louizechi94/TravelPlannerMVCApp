using Microsoft.AspNetCore.Mvc;
using TravelPlanner.Models.ViewModeles.UserModels;
using TravelPlanner.Services.Services.UserServices;

namespace TravelPlannerMVCApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetUsers();
            return View(users);
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var user = await _userService.GetUser(id);
            return View(user);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserCreate userCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _userService.AddUser(userCreate))
            {
                return RedirectToAction(nameof(Index));
            }

            return View(userCreate);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _userService.GetUser(id);
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserEdit userEdit)
        {
            if (!ModelState.IsValid)
            { 
                return BadRequest(ModelState);
            }
            if (await _userService.UpdateUser(userEdit))
                { 
                    return RedirectToAction(nameof(Index));
                }
            return View(userEdit);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            var user = await _userService.GetUser(id.Value);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userService.GetUser(id);
            if (await _userService.DeleteUser(user.Id))
            {
                return RedirectToAction(nameof(Index));
            }
            else
               return UnprocessableEntity();
        }

       

       
    }
}
