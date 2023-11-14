using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Models
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]

        [Range(1, 1000, ErrorMessage = "Price should be between $1 and $1000")]
        public double Price { get; set; }

        [Range(1, 100, ErrorMessage = "Quantity should be between 1 and 100")]
        [Required]
        public int Quantity { get; set; }

        public DateTime ImportDate { get; set; }

        [Required]
        public DateTime? ExpirationDate { get; set; }
    }
}
