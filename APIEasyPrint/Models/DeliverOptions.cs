using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIEasyPrint.Models
{
    public class DeliverOptions
    {
        [Key]
        public Guid Id { set; get; }
        public bool isPickUp { set; get; }
       public double pickUpPrice { set; get; }
       public bool isHomeDelivery { set; get; }
       public double homeDeliveryPrice { set; get; }
       public bool isMailDelivery { set; get; }
       public double mailDeliveryPrice { set; get; }




        [ForeignKey("PrintigShopFK")]
        public Guid printingShopId { get; set; }
        public PrintingShop printingShop { get; set; }
    }
}
