using System.ComponentModel.DataAnnotations;

namespace Order.MicroService.Models
{
    public class PaymentType
    {
        [Key]
        public int PaymentTypeId { get; set; }
        public string PaymentTypeDesc { get; set; }
    }
}