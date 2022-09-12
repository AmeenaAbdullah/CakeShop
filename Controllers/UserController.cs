using CakesShop.Models;
using Microsoft.AspNetCore.Mvc;
using CakesShop.Models.Interfaces;
using System.Reflection.Metadata;
using System;
using AutoMapper;

namespace CakesShop.Controllers
{
    public class UserController : Controller
    {

        private readonly IUser _userRepo;
        private readonly IMapper _mapper;
        public UserController(IUser _user, IMapper mapper)
        {

            _userRepo = _user;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }
       
        [HttpPost]
        public IActionResult Signup( User u)
        {
            if (ModelState.IsValid) { 
               

            _userRepo.Add_User(u);

               return View("Home");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User u)
        {
            string data = String.Empty;
            if (HttpContext.Session.Keys.Contains("SessionCreate"))
            {
                string firsttime = HttpContext.Session.GetString("SessionCreate");
                data = "welcome back" + firsttime;
            }
            else
            {
                data = "You visit first time";
                HttpContext.Session.SetString("SessionCreate", System.DateTime.Now.ToString());
            }

            bool i= _userRepo.UserExist(u);
            if (i)
                return View("Home");
            else
                return View();

        }


        public IActionResult Logout()
        {
            HttpContext.Session.Remove("SessionCreate");
            return View("Home");
        }
        [HttpGet]
        public IActionResult Home()
        {
            string data = String.Empty;
            if (HttpContext.Session.Keys.Contains("first_request"))
            {
                string firsttime = HttpContext.Session.GetString("first_request");
                data = "welcome back" + firsttime;
            }
            else
            {
                data = "You visit first time";
                HttpContext.Session.SetString("first_request", System.DateTime.Now.ToString());
            }
            
            return View();
        }
        public IActionResult remove()
        {
            HttpContext.Session.Remove("first_request");
            return View("Home");
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
