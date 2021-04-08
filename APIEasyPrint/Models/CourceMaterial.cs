using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIEasyPrint.Models
{
    public class CourceMaterial
    {
        [Key]
        public Guid courceMaterialId { get; set; }


        [Display(Name = "اسم المنتج")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "هذا الحقل مطلوب ")]
        [StringLength(100)]
        public string courceMaterialTitle { get; set; }



        [Display(Name = " وصف المنتج")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "هذا الحقل مطلوب ")]
        [StringLength(300)]
        public string courceMaterialDescreption { get; set; }

        [Display(Name = "سعر المنتج")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "هذا الحقل مطلوب ")]
        public double courceMaterialPrice { get; set; }

        [Display(Name = "توفر المنتج")]
        [Required(ErrorMessage = "هذا الحقل مطلوب ")]
        public bool isAvailable { get; set; }

        [ForeignKey("SubjectFK")]
        public Guid SubjectId { get; set; }
        public Subject courceMaterialSelectedSubject { get; set; }

        [ForeignKey("PrintigShopFK")]
        public Guid printingShopId { get; set; }
        public PrintingShop printingShop { get; set; }


    }
}
