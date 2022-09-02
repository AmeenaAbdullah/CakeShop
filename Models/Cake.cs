using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CakesShop.Models
{
    public partial class Cake
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Category")]
        public string? Category { get; set; }
        [Required(ErrorMessage = "Please enter Price")]
        public decimal? Price { get; set; }
        [Required(ErrorMessage = "Please enter pond")]
        public decimal? Pond { get; set; }
       
        [Required(ErrorMessage = "Please enter description")]
       public string? Description { get; set; }
        [Required(ErrorMessage = "Please enter File path")]
        public string? Image{ get; set; }
    }
}
