using Microsoft.AspNetCore.Mvc;

namespace CakesShop.Models.Interfaces
{
    public interface ICake
    {
        public void Add_cake(Cake cake);
        public List<Cake> GetAllCakes();
        public List<Cake> GetTopCakes();
        public bool Delete(int id);
        public List<Cake> GetCakesByCategory(string c);
        public Cake GetCakeById(int c);
        public void UpdateCake(Cake C);

       //public List<Cake> GetCakesByCategory(string c, string SearchValue);


    }
}
