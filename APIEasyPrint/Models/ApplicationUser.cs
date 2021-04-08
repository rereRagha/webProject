using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEasyPrint.Models
{
    public class ApplicationUser : IdentityUser
    {
        public Guid prentingShopId { get; set; }
        public string prenterName { get; set; }
    }
}
