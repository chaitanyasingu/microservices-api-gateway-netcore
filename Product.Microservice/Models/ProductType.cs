using System.ComponentModel.DataAnnotations;

namespace Product.Microservice.Models
{
    public class ProductType
    {
        [Key]
        public int ProductTypeId { get; set; }
        public string ProductTypeDesc { get; set; }

    }
}
