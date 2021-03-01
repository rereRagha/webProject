using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIEasyPrint.APIModels
{
    public class PrintingShopApiMode
    {
        public class Request
        {
            public string prenterName { get; set; }
            public bool isCourseMaterial { get; set; }
            public bool isService { get; set; }
            public string ownerId { get; set; }


        }

        public class Response
        {
            public string prentingShopId { get; set; }
            public string prenterName { get; set; }
            public bool isCourseMaterial { get; set; }
            public bool isService { get; set; }
            public string ownerId { get; set; }

        }
    }
}
