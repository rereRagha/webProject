using APIEasyPrint.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIEasyPrint.APIModels
{
    public class SignInApiModel
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
            public string UserName { get; set; }
            
        }

        public class Response
        {

            public string Token { get; set; }
            public Customer customer { get; set; }

        }
    }
}
