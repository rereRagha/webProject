using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIEasyPrint.Models
{
    public class PublicPromotionCode
    {



        [Key]
        public Guid publicPromotionCodeId { get; set; }


        [Display(Name = "نص  كود التخفيض")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "هذا الحقل مطلوب ")]
        [StringLength(50)]
        public string publicPromotionCodeString { get; set; }


        [Display(Name = "تاريخ بداية كود التخفيض")]
        [DataType(DataType.Date)]
        public DateTime startDate { get; set; }



        [Display(Name = "تاريخ انتهاء كود التخفيض")]
        [DataType(DataType.Date)]
        public DateTime expireDate { get; set; }


        public bool isExpired { set; get; }




        [ForeignKey("PrintigShopFK")]
        public Guid printingShopId { get; set; }
        public PrintingShop printingShop { get; set; }
    }
}
