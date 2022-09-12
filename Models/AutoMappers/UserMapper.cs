using AutoMapper;
using CakesShop.Models.ViewModels;

namespace CakesShop.Models.AutoMappers
{
    public class UserMapper : Profile
    {
      
        public UserMapper(){
          CreateMap<User, UserViewModel>();

      }
    }

}