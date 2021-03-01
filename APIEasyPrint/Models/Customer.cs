using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIEasyPrint.Models
{
    public class Customer : IdentityUser
    {
       
        public List<Suggestion> suggestions { set; get; }
        public List<PrivatePromotionCode> privatePromotionCodes { set; get; }
        public List<Document> documents { set; get; }

        //list of orders 
        //list of checkouts 
    }
}
