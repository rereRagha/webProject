using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEasyPrint.APIModels
{
    public class CourceMaterialApiModel
    {
        public class Request
        {
            public string courceMaterialTitle { get; set; }
            public string courceMaterialDescreption { get; set; }
            public double courceMaterialPrice { get; set; }
            public bool isAvailable { get; set; }
            public Guid SubjectId { get; set; }
            public Guid printingShopId { get; set; }

        }

        public class Response
        {
            public Guid courceMaterialId { get; set; }
            public string courceMaterialTitle { get; set; }
            public string courceMaterialDescreption { get; set; }
            public double courceMaterialPrice { get; set; }
            public bool isAvailable { get; set; }
            public Guid SubjectId { get; set; }
            public Guid printingShopId { get; set; }

        }
    }
}
