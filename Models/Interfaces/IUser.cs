using Microsoft.AspNetCore.Mvc;

namespace CakesShop.Models.Interfaces
{
    public interface IUser 
    {
        public void Add_User(User user);
        public bool UserExist(User u);
        //public User Get_user(int id);


    }
}
