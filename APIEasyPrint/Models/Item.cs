using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIEasyPrint.Models
{
    public class Item
    {
        [Key]
        public Guid itemId { set; get; }
        
        public bool isCourceMaterial { set; get; }
        public bool isPrintingOrder { set; get; }

        public double totalPriceOfTheItem { set; get; }


        [ForeignKey("CourceMaterialFK")]
        public Guid courceMaterialId { set; get; }
        public CourceMaterial courceMaterial { set; get; }


        [ForeignKey("DocumentFK")]
        public Guid docId { get; set; }
        public Document document { set; get; }



        [ForeignKey("OrderFK")]
        public Guid orderId { set; get; }
        public Order order { set; get; }


        [ForeignKey("PrintingShopFK")]
        public Guid printingShopId { set; get; }
        public PrintingShop printingShop { set; get; }
    }
}