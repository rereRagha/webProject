using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEasyPrint.APIModels
{
    public class DriverRegister
    {
        public class Request
        {
            public string PrintrtId { get; set; }
            public string Email { get; set; }
            public string PasswordHash { get; set; }
            public string PhoneNumber { get; set; }
            public string UserName { get; set; }

        }

        public class Response
        {

            public string Token { get; set; }
            public string Id { get; set; }
            public bool EmailConfiremd { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public string UserName { get; set; }
            public string ErrorMessage { get; set; }

        }
    }
}
