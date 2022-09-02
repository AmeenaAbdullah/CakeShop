using CakesShop.Models;
using Microsoft.AspNetCore.Mvc;
using CakesShop.Models.Interfaces;
using System.Reflection.Metadata;

namespace CakesShop.Controllers
{
    public class UserController : Controller
    {

        private readonly IUser _userRepo;
        public UserController(IUser _user)
        {

            _userRepo = _user;
        }
        [HttpGet]
        public IActionResult signup()
        {
            return View();
        }
       
        [HttpPost]
        public IActionResult signup(User u)
        {
            if (ModelState.IsValid)
            {
                _userRepo.Add_User(u);

               return this.Ok($"Form Data received!");
            }
            return BadRequest("Enter required fields");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Home()
        {

            return View();
        }
        [HttpGet]
        public IActionResult Items()
        {

            return View();
        }
        [HttpGet]
        public IActionResult BreakFast_Lunch()
        {

            return View();
        }
        [HttpGet]
        public IActionResult Drink()
        {

            return View();
        }
        [HttpGet]
        public IActionResult Contact()
        {

            return View();
        }
        public PartialViewResult Add()
        {
            User u = new User();
            u.Name = "aaa";
            u.Password = "133";
            return PartialView("viewdata", u);
        }
    }
}
