using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public ProductType ProductType { get; set; }
        [Required]
        public string ProductName { get; set; }
        public long OriginalPrice { get; set; }
        public bool IsDiscountAvailable { get; set; }
        public long DiscountPercentage { get; set; }
        public string VendorName { get; set; }
        public string VendorAddress { get; set; }
    }
}
