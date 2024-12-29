using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEasyPrint.APIModels
{
    public class DriverOrders
    {
        public class Response
        {

            public string CustomerPhome { set; get; }
            public string CustomerEmail { set; get; }
            public string orderId { set; get; }
            public double total { set; get; }
            public string city { get; set; }
            public string neighborhood { set; get; }
            public string street { set; get; }
            public string adressLine { set; get; }
            public int deleveryStatusNumber { set; get; }
            public string deleveryStatus { set; get; }

        }
    }
}
