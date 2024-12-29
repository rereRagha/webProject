using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIEasyPrint.Models
{
    public class GlobalNotification
    {
        [Key]
        public Guid globalNotificationId { get; set; }


        [Display(Name = "عنوان التنبيه")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "هذا الحقل مطلوب ")]
        [StringLength(100)]
        public string notificationTitle { get; set; }



        [Display(Name = "وصف التنبيه")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "هذا الحقل مطلوب ")]
        [StringLength(500)]
        public string notificationDescription { get; set; }



        [Display(Name = "تاريخ التنبيه")]
        [DataType(DataType.Date)]
         public DateTime notificationDate { get; set; }




        [ForeignKey("teatcherFK")]
        public Guid teatcherId { get; set; }
        public Teatcher teatcher { get; set; }

    }
}
