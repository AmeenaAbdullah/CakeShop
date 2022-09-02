using Microsoft.AspNetCore.Mvc;

namespace CakesShop.ViewComponents
{
    public class test : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
