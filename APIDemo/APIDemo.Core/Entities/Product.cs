using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace APIDemo.Core.Entities
{
    public class Product : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [RegularExpression(@"\w+\.(jpg|png)")]
        public string ImageUrl { get; set; }

        public ProductType ProductType { get; set; }
        [ForeignKey("ProductType")]
        public int ProductTypeId { get; set; }
        public ProductBrand ProductBrand { get; set; }
        [ForeignKey("ProductBrand")]

        public int ProductBrandId { get; set; }
    }
    
}
