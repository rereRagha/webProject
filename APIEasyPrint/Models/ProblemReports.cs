using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIEasyPrint.Models
{
    public class ProblemReports
    {

        [Key]
        public Guid problemId { get; set; }

        [Display(Name = "عنوان المشكلة")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "هذا الحقل مطلوب ")]
        [StringLength(100)]
        public string problemTitle { get; set; }



        [Display(Name = "وصف المشكلة")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "هذا الحقل مطلوب ")]
        [StringLength(500)]
        public string problemDescription { get; set; }



        [Display(Name = "تاريخ المشكلة")]
        [DataType(DataType.Date)]
        public DateTime problemDate { get; set; }




        [ForeignKey("PrintingShopFK")]
        public Guid PrintingShopId { get; set; }
        public PrintingShop printingShop { get; set; }



        [ForeignKey("AdminFK")]
        public Guid adminId { get; set; }
        public Admin admin { get; set; }


    }
}