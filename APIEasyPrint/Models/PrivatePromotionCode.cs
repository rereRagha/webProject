using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIEasyPrint.Models
{
    public class PrivatePromotionCode
    {

        [Key]
        public Guid privatePromotionCodeId { get; set; }


        [Display(Name = "نص  كود التخفيض")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "هذا الحقل مطلوب ")]
        [StringLength(50)]
        public string privatePromotionCodeString { get; set; }


        [Display(Name = "تاريخ بداية كود التخفيض")]
        [DataType(DataType.Date)]
        public DateTime startDate { get; set; }



        [Display(Name = "تاريخ انتهاء كود التخفيض")]
        [DataType(DataType.Date)]
        public DateTime expireDate { get; set; }


        public bool isExpired { set; get; }
        public bool isUsed { set; get; }


        [ForeignKey("CustomerFK")]
        public Guid CustomerId { get; set; }
        public Customer customer { get; set; }

        [ForeignKey("PrintigShopFK")]
        public Guid printingShopId { get; set; }
        public PrintingShop printingShop { get; set; }
    }
}