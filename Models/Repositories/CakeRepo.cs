﻿using Microsoft.AspNetCore.Mvc;
using CakesShop.Models.Interfaces;
using System.Linq;

namespace CakesShop.Models.Repositories
{
    public class CakeRepo : ICake
    {
        CakesShopManagementSystemContext dbcontext;
        public CakeRepo()
        {
            dbcontext = new CakesShopManagementSystemContext();
        }


        public void Add_cake(Cake cake)
        {

            dbcontext.Cakes.Add(cake);

            dbcontext.SaveChanges();
        }
      
        public  List<Cake> GetAllCakes()
        {
            return dbcontext.Cakes
                  .Select(cake => new Cake()
                  {
                      Category = cake.Category,
                      Description = cake.Description,
                      Id = cake.Id,
                      Price = cake.Price,
                      Image = cake.Image,
                  }).ToList();
        }
        public List<Cake> GetTopCakes()
        {
            return dbcontext.Cakes
                  .Select(cake => new Cake()
                  {
                      Category = cake.Category,
                      Description = cake.Description,
                      Id = cake.Id,
                      Price = cake.Price,
                      Image = cake.Image,
                  }).Take(8).ToList();
        }

    }
}