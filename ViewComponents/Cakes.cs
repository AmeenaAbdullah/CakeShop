﻿using CakesShop.Models;
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
        public IViewComponentResult Invoke(bool allitems)
        {
            List<Cake> c;
            if (allitems)
                 c = _cakeRepo.GetAllCakes();
            else
                c = _cakeRepo.GetTopCakes();
            return View("Default", c);
        }
    }
}