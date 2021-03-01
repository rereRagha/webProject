using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIEasyPrint.Models
{
    public class DeliveryDriver : IdentityUser
    {
        [Key]
        public Guid Id { set; get; }

       
        public PrintingShop printingShop { get; set; }
        public List<Order> orders { set; get; }
    }
}
