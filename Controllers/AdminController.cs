using CakesShop.Models;
using CakesShop.Models.Interfaces;
using CakesShop.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CakesShop.Controllers
{
    public class AdminController : Controller
    {
        private readonly ICake _cakeRepo;
        private readonly IWebHostEnvironment Environment;

      
        public AdminController(ICake _c, IWebHostEnvironment environment)
        {

            _cakeRepo = _c;
            Environment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Cake c, IFormFile postedFiles)
        {
            string wwwPath = this.Environment.WebRootPath;

            string path = Path.Combine(wwwPath, "Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
             var fileName = Path.GetFileName(postedFiles.FileName);
                var pathWithFileName = Path.Combine(path, fileName);
                using (FileStream stream = new FileStream(pathWithFileName, FileMode.Create))
                {
                postedFiles.CopyTo(stream);
                    ViewBag.Message = "file uploaded successfully";
                }

            //Cake c1 = new Cake();
            //c1 = c;
            string imgpath = "/Uploads/" +postedFiles.FileName;
            c.Image = imgpath;

                _cakeRepo.Add_cake(c);
                return View();
        }


        [Route("cake-update/{id:int:min(1)}", Name = "cakeupdateroot")]
        public async Task<ViewResult> UpdateProduct(int id)
        {
            Cake data = _cakeRepo.GetCakeById(id);

            return View(data);
        }

        [Route("cake-updatepost/{id:int:min(1)}", Name = "cakeupdaterootpost")]
        public IActionResult UpdateProduct(int id,Cake c,IFormFile postedFiles)
        {
           
            Cake data = _cakeRepo.GetCakeById(id);
            data.Price = c.Price;
            data.Category = c.Category;
            data.Description = c.Description;
            data.Pond = c.Pond;
            if (postedFiles != null)
            {
                deleteUploadImge(id);
                string wwwPath = this.Environment.WebRootPath;
                string path = Path.Combine(wwwPath, "Uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                var fileName = Path.GetFileName(postedFiles.FileName);
                var pathWithFileName = Path.Combine(path, fileName);
                using (FileStream stream = new FileStream(pathWithFileName, FileMode.Create))
                {
                    postedFiles.CopyTo(stream);
                    ViewBag.Message = "file uploaded successfully";
                }


                string imgpath = "/Uploads/" + postedFiles.FileName;
                data.Image = imgpath;
            }
           

            _cakeRepo.UpdateCake(data);

            return View("Index");
        }





        public IActionResult Addimg()
        {
            return View();
        }
        
        
        
        
        [HttpPost]
        
        
        public IActionResult Addimg(List<IFormFile> postedFiles)
        {
            string wwwPath = this.Environment.WebRootPath;

            string path = Path.Combine(wwwPath, "Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (var file in postedFiles)
            {
                var fileName = Path.GetFileName(file.FileName);
                var pathWithFileName = Path.Combine(path, fileName);
                using (FileStream stream = new FileStream(pathWithFileName, FileMode.Create))
                {
                    file.CopyTo(stream);
                    ViewBag.Message = "file uploaded successfully";
                }
            }
            return View();
        }
        public void deleteUploadImge(int id)
        {
            Cake data = _cakeRepo.GetCakeById(id);
            string wwwPath = this.Environment.WebRootPath;

            string path = Path.Combine(wwwPath, "Uploads");
            string img = data.Image;
            var pathWithFileName = Path.Combine(path, img);
            System.IO.File.Delete(pathWithFileName);
        }
    }
}

