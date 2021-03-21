using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIEasyPrint.APIModels
{
    public class PrintingShopRegisterApiModel
    {

        public class Request
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            public string PasswordHash { get; set; }

            [Required]
            public string PhoneNumber { get; set; }

            [Required]
            public string FullName { get; set; }

        }

        public class Response
        {

            public string Token { get; set; }
            public string Id { get; set; }
            public bool EmailConfiremd { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public string FullName { get; set; }
            public string ErrorMessage { get; set; }

        }

    }
}
