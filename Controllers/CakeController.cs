using CakesShop.Models;
using CakesShop.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CakesShop.Controllers
{
    public class CakeController : Controller
    {

        private readonly ICake _cakeRepo;
        public CakeController(ICake c)
        {

            _cakeRepo = c;
        }
      

        public PartialViewResult getCakes() {
            List<Cake> cakes = _cakeRepo.GetAllCakes();
            
            return PartialView("_getAllCakes",cakes);
        }

        public IActionResult PlaceHolder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DeleteCake([FromBody] int id)
        {
          
            Boolean i=_cakeRepo.Delete(id);
            if(i)
            return this.Ok($"Form Data received!");

            return this.Ok($"Form Data received!");
        }
        [HttpGet]
        public IActionResult Search()
        {

            return View(_cakeRepo.GetAllCakes());
        }

        [HttpPost]

        public JsonResult GetSearchData(String customerName)
        {


            List<Cake> cake = new List<Cake>();

            
            cake = _cakeRepo.GetAllCakes();
            
            return Json(cake.ToList());
        }
    }
}
