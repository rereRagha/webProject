using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIEasyPrint.Models
{
    public class Service
    {
        [Key]
        public Guid serviceId { get; set; }


        [Display(Name = "اسم الخدمة")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "هذا الحقل مطلوب ")]
        [StringLength(100)]
        public string serviceTitle { get; set; }
        public double Price { get; set; }


        public Guid SellUnitsellUnitId { get; set; }

        [Display(Name = " وصف الخدمة")]
        [DataType(DataType.MultilineText)]
        [StringLength(300)]
        public string serviceDescreption { get; set; }
        public Guid printingShopId { get; set; }

    }
}
