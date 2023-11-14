using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Models
{
    public class MenuItemIngredient
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "MenuItem")]
        public int MenuItemId { get; set; }

        [ValidateNever]
        [ForeignKey("MenuItemId")]
        public MenuItem MenuItem { get; set; }

        [Display(Name = "Ingredient")]
        public int IngredientId { get; set; }

        [ValidateNever]
        [ForeignKey("IngredientId")]
        public Ingredient Ingredient { get; set; }
    }
}
