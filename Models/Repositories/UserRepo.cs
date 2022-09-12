using Microsoft.AspNetCore.Mvc;
using CakesShop.Models.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CakesShop.Models.Repositories
{
    public class UserRepo : IUser
    {
        CakesShopManagementSystemContext dbcontext;
        public UserRepo()
        {
            dbcontext = new CakesShopManagementSystemContext();
        }


        public void Add_User(User user)
        {
            //Add into database
         
        dbcontext.Users.Add(user);

            dbcontext.SaveChanges();


        }
       public bool UserExist(User user)
        {
            return dbcontext.Users.Any(u => u.Name == user.Name && u.Password == user.Password);
        }

        
        //public User Get_user(int id)
        //{
        //   User user= dbcontext.Users.Find(id);
        //    return user;
        //}
    }
}
