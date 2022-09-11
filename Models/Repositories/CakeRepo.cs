using Microsoft.AspNetCore.Mvc;
using CakesShop.Models.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage;

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
            return dbcontext.Cakes.Select(cake => new Cake()
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
        public Boolean Delete(int id)
        {
            Cake c= dbcontext.Cakes.Find(id);
            if (c != null)
            {
                dbcontext.Remove(c);
                dbcontext.SaveChanges();
                return true;
            }
        
            return false;
        }


        public List<Cake> GetCakesByCategory(string c)
        {
            List<Cake> cakes = new List<Cake>();
            c = c.ToLower();
            if (!String.IsNullOrEmpty(c))
            {
                cakes = dbcontext.Cakes.Where(s => s.Category.ToLower().Contains(c)).ToList(); 
            }
            return cakes;
        }
        
        public Cake GetCakeById(int c)
        {
            Cake cakes = new Cake();

           cakes = dbcontext.Cakes.Find(c);
           
            return cakes;
        }
        public void UpdateCake(Cake updatecake)
        {
          
            if (updatecake != null)
            {
                Cake cake = dbcontext.Cakes.Where(c=>c.Id==updatecake.Id).FirstOrDefault();
                 
                cake.Description = updatecake.Description;
                cake.Price = updatecake.Price;
                cake.Pond = updatecake.Pond;
                cake.Image = updatecake.Image;

                dbcontext.Cakes.Update(cake);
                dbcontext.SaveChanges();
            }
        }
    }
}
