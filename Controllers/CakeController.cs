using CakesShop.Models;
using CakesShop.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CakesShop.Controllers
{

    public class CakeController : Controller
    {

        private readonly ICake _cakeRepo;
        private readonly IWebHostEnvironment Environment;
        public CakeController(ICake c, IWebHostEnvironment e)
        {

            _cakeRepo = c;
            Environment = e;
        }
      

        public PartialViewResult getCakes() {
            List<Cake> cakes = _cakeRepo.GetAllCakes();
            
            return PartialView("_getAllCakes",cakes);
        }

        public IActionResult PlaceHolder()
        {
            return View();
        }
        
      [Route("cake-delete/{id:int:min(1)}", Name = "cakeDeleteRoute")]
        public IActionResult DeleteCake(int id)
        {
            //Delete Upload folder
              deleteUploadImge(id);
              Boolean i=_cakeRepo.Delete(id);
            if(i)
            return this.RedirectToAction("Index","Admin");

            return this.Ok($"Not Found!");
        }
        [HttpGet]
        public IActionResult Search()
        {

            return View(_cakeRepo.GetAllCakes());
        }

        [HttpPost]

        public JsonResult GetSearchData(String fullName)
        {


            List<Cake> cake = new List<Cake>();

            
            cake = _cakeRepo.GetCakesByCategory(fullName);
            
            return Json(cake.ToList());
        }




        public IActionResult CakesViewComponent(String searcval)
        {
            List<Cake> cake = new List<Cake>();

            cake = _cakeRepo.GetCakesByCategory(searcval);

            return ViewComponent("Cakes", new { allitems = false ,view = searcval });
        }


        [Route("cake-details/{id:int:min(1)}", Name = "cakeDetailsRoute")]
        public async Task<ViewResult> GetCake(int id)
        {
            Cake data = _cakeRepo.GetCakeById(id);

            return View(data);
        }
        public void deleteUploadImge(int id)
        {
            Cake data = _cakeRepo.GetCakeById(id);
            string wwwPath = this.Environment.WebRootPath;

            string path = Path.Combine(wwwPath, "Uploads");
            var fileName = Path.GetFileName(data.Image);
            var pathWithFileName = Path.Combine(path, fileName);
            System.IO.File.Delete(pathWithFileName);
        }

    }
}
