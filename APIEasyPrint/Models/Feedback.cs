using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIEasyPrint.Models
{
    public class Feedback
    {
        [Key]
        public Guid feedBackId { get; set; }


        [Display(Name = "تقييم الخدمة")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "هذا الحقل مطلوب ")]
        public int feedBackRate { get; set; }



        [Display(Name = "ملاحظات")]
        [DataType(DataType.MultilineText)]
        [StringLength(500)]
        public string feedBackDescription { get; set; }



        [DataType(DataType.Date)]
        public DateTime feedBackDate { get; set; }




        [ForeignKey("CustomerFK")]
        public Guid CustomerId { get; set; }
        public Customer customer { get; set; }


        [ForeignKey("OrderFK" )]
        public Guid orderId { set; get; }
        public Order order { set; get; }

    }
}
