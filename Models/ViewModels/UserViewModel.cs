using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CakesShop.Models.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Please enter password")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
