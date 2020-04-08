using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product.Microservice.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [ForeignKey("ProductTypeId")]
        public ProductType ProductType { get; set; }
        public int ProductTypeId { get; set; }
        [Required]
        public string ProductName { get; set; }
        public long OriginalPrice { get; set; }
        public bool IsDiscountAvailable { get; set; }
        public long DiscountPercentage { get; set; }
        public string VendorName { get; set; }
        public string VendorAddress { get; set; }
    }
}
