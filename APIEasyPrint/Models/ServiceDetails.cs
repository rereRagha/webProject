using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIEasyPrint.Models
{
    public class ServiceDetails
    {
        [Key]
        public Guid Id { set; get; }
        public Guid selectedServiceId { get; set; }

        public Guid itemId { set; get; }




        [Display(Name = "سعر الخدمة")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "هذا الحقل مطلوب ")]
        public double ServicePrice { get; set; }

        public Guid printingShopId { get; set; }
    }
}
