using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEasyPrint.APIModels
{
    public class UpdateCustomerInfoApiModel
    {
        public class Request { 
        public string Id { get; set; }
        public bool EmailConfiremd { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }


          }

        public class Response
        {
            public string Id { get; set; }
            public bool EmailConfiremd { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public string UserName { get; set; }

            public string ErrorMessage { get; set; }

        }
    }

}
