using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEasyPrint.APIModels
{
    public class AddressApiModel
    {
        public class Request
        {

            public string userId { set; get; }
            public string country { set; get; }
            public string city { get; set; }
            public string neighborhood { set; get; }
            public string street { set; get; }
            public string adressLine { set; get; }
            public string postcode { set; get; }

        }
    

        public class Response
        {
            public string userId { set; get; }
            public string country { set; get; }
            public string city { get; set; }
            public string neighborhood { set; get; }
            public string street { set; get; }
            public string adressLine { set; get; }
            public string postcode { set; get; }


        }

      

    }
}
