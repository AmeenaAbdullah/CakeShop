using CakesShop.Models;
using CakesShop.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
    }
}
