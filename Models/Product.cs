using System.ComponentModel.DataAnnotations;

namespace MVC_Aptech.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string? Name { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public float Price { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Count { get; set; }

        public string? Description { get; set; }

    }
}
