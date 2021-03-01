using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIEasyPrint.Models
{
    public class Document
    {
        [Key]
        public Guid docId { set; get; }

        [Display(Name = "عنوان الملف")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "هذا الحقل مطلوب ")]
        [StringLength(100)]
        public string docTitle { set; get; }

        [Display(Name = "الملف")]
        [DataType(DataType.Upload)]
        public string docLocation { set; get; }


        [ForeignKey("CustomerFK")]
        public Guid CustomerId { get; set; }
        public Customer customer { get; set; }
    }
}