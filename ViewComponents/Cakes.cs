using CakesShop.Models;
using CakesShop.Models.Interfaces;
using CakesShop.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CakesShop.ViewComponents
{
    public class Cakes : ViewComponent
    {
       
        private readonly ICake _cakeRepo;
        public Cakes(ICake _c)
        {

            _cakeRepo = _c;
        }
        public IViewComponentResult Invoke(bool allitems, string view)
        {
            List<Cake> c;
            if (view == "User" || view=="Admin")
            {  if (allitems)
                    c = _cakeRepo.GetAllCakes();

                else
                    c = _cakeRepo.GetTopCakes();

                if (view == "User")
                    return View("Default", c);
                else
                    return View("Default2", c);
            }
            else
            {
                c = _cakeRepo.GetCakesByCategory(view);
                return View("Default", c);
            }
        }
    }
}
