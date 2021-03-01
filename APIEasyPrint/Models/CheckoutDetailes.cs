using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIEasyPrint.Models
{
    public class CheckoutDetailes
    {
        [Key]
        public Guid invoiceId { set; get; }
        [Required]
        public string paymentMethod { set; get; }
        [Required]
        public double amount { set; get; }
        [Required]
        [Display(Name = "تاريخ التوصيل")]
        [DataType(DataType.Date)]
        public DateTime deliveryDate { set; get; }
        [Required]
        public DateTime paymentDate { set; get; }

        [ForeignKey("OrderFK")]
        public Guid orderId { set; get; }
        public Order order { set; get; }
    }
}
