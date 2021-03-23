using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIEasyPrint.Models
{
    public class Order
    {
        [Key]
        public Guid orderId { set; get; }
        public List<Item> items { set; get; }
        public List<PrintingShop> printingShops { set; get; }

        
        public double total { set; get; }
        public int numberOfItems { set; get; }

        public DateTime orderCreationDate { set; get; }
        public DateTime orderEndDate { set; get; }


        public Status orderStatus { set; get; }
        public Status deliveryStatus { set; get; }


        [ForeignKey("CustomerFK")]
        public Guid CustomerId { get; set; }
        public Customer customer { get; set; }
    }
}
