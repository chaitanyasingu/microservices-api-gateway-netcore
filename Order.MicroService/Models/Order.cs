using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Order.MicroService.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime PlacedOn { get; set; }
        public List<Products> Products { get; set; }

        [ForeignKey("PaymentTypeId")]
        public int? PaymentTypeId { get; set; }
        public PaymentType PaymentType { get; set; }
        public decimal TotalAmount { get; set; }

    }

    public class Products
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("OrderId")]
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
