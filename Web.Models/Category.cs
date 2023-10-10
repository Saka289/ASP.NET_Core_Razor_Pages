using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Display(Name = "Display Order")]
        [Range(0, 100, ErrorMessage = "Display order must be range of 1-100!!!")]
        public int DisplayOrder { get; set; }
    }
}
