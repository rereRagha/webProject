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

        public List<SellUnit> allSellUnits { set; get; }

        [Display(Name = "وحدة البيع")]
        [DataType(DataType.Text)]
        public SellUnit selectedSellUnit { get; set; }
        // public Guid selectedSellUnitsellUnitId { get; set; }

        [Display(Name = " وصف الخدمة")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "هذا الحقل مطلوب ")]
        [StringLength(300)]
        public string serviceDescreption { get; set; }
    }
}
