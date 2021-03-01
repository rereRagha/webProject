using System;
using System.ComponentModel.DataAnnotations;

namespace APIEasyPrint.Models
{
    public class SellUnit
    {
        [Key]
        public Guid sellUnitId { get; set; }


        [Display(Name = "وحدة البيع")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "هذا الحقل مطلوب ")]
        [StringLength(200)]
        public string sellUnitName { get; set; }


        [Display(Name = "اقل عدد يمكن بيعة من الوحدة")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "هذا الحقل مطلوب ")]
        [StringLength(200)]
        public int minimumNumber { get; set; }
    }
}