using APIEasyPrint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEasyPrint.APIModels
{
    public class OrderApiModel
    {
        public class Request
        {
            //not needed, its a get method 
           public string printerId { set; get; }


        }


        public class Response
        {
            public string Id { set; get; }
            public string itemId { set; get; }
            public int orderStatusId { set; get; }
            public string orderStatus { set; get; }
            public int deliveryStatusId { set; get; }

            public string deliveryStatus { set; get; }
            public DateTime orderDate { set; get; }
            public string customerId { set; get; }
            public string customerName { set; get; }
            public double total { set; get; }

        }
    }
}