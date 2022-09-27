using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CakesShop.Models
{
    public partial class User : FullAudit_User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter name")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Please enter email")]
        [EmailAddress]
        [Column(TypeName = "varchar(max)")]
        public string? Gmail { get; set; }
    }
}
