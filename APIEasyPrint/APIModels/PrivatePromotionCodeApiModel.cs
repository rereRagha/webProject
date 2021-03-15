using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEasyPrint.APIModels
{
    public class PrivatePromotionCodeApiModel
    {
        public class Request
        {
            public string privatePromotionCodeId { get; set; }
            public string privatePromotionCodeString { get; set; }
            public DateTime startDate { get; set; }
            public DateTime expireDate { get; set; }
            public bool isExpired { set; get; }
            public bool isUsed { set; get; }
            public string CustomerId { get; set; }
            public string printingShopId { get; set; }
        }
        public class Response
        {
            public string privatePromotionCodeId { get; set; }
            public string privatePromotionCodeString { get; set; }
            public DateTime startDate { get; set; }
            public DateTime expireDate { get; set; }
            public bool isExpired { set; get; }
            public bool isUsed { set; get; }
            public string CustomerId { get; set; }
            public string printingShopId { get; set; }

        }

    }
}
