using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIEasyPrint.Models
{
    public class Suggestion
    {
        [Key]
        public Guid suggestionId { get; set; }


        [Display(Name = "عنوان الاقتراح")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "هذا الحقل مطلوب ")]
        [StringLength(100)]
        public string suggestionTitle { get; set; }



        [Display(Name = "وصف الاقتراح")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "هذا الحقل مطلوب ")]
        [StringLength(500)]
        public string suggestionDescription { get; set; }



        [Display(Name = "تاريخ الاقتراح")]
        [DataType(DataType.Date)]
         public DateTime suggestionDate { get; set; }




        [ForeignKey("CustomerFK")]
        public Guid CustomerId { get; set; }
        public Customer customer { get; set; }



        [ForeignKey("AdminFK")]
        public Guid adminId { get; set; }
        public Admin admin { get; set; }

    }
}
