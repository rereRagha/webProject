using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEasyPrint.APIModels
{
    public class AddItemApiModel
    {
        public class Request
        {
            public string orderId { get; set; }
            public bool isCourceMaterial { get; set; }
            public bool isPrintingOrder { get; set; }
            public double totalPriceOfTheItem { set; get; }
            public string courseId { set; get; }
            public string docId { set; get; }
            public string  printingShopId { set; get; }
            public string customerId { set; get; }
            public int numberOfItems { set; get; }
            public string description { set; get; }

        }

        public class Response
        {
            public List<itemView> Items { set; get; }
            public string orderId { set; get; }
            public string errorMassage { set; get; }
            
        }

        public class ResponseByOneItem
        {
            public string orderId { set; get; }
            public string errorMassage { set; get; }
            public string itemId { set; get; }
            public double itemPrice { set; get; }
            public string printingShopID { set; get; }

        }

        public class itemView
        {
            public string itemId { set; get; }
            public double itemPrice { set; get; }
            public string printingShopID { set; get; }
            public string courseID { set; get; }
            public string courseName { set; get; }

            public bool isCourceMaterial { get; set; }
            public bool isPrintingOrder { get; set; }

            public string servicName { get; set;  }

        }


    }
}
