using System.ComponentModel.DataAnnotations;

namespace APIDemo.Core.Entities
{
    public class ProductType : BaseEntity
    {
        [Required]
        [MaxLength(25)]
        public string Name  { get; set; }
    }
}