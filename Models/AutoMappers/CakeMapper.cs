
using AutoMapper;
using CakesShop.Models.ViewModels;

namespace CakesShop.Models.AutoMappers
{
    public class CakeMapper : Profile
    {

        public CakeMapper()
        {
            CreateMap<Cake, CakeViewModel>();

        }
    }

}