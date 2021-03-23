using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIEasyPrint.Models
{
    public class Address
    {
        [Key]
        public Guid UserId { set; get; }

        [Display(Name = "الدولة")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "هذا الحقل مطلوب ")]
        [StringLength(100)]
        public string country { set; get; }


        [Display(Name = "المدينة")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "هذا الحقل مطلوب ")]
        [StringLength(100)]
        public string city { get; set; }


        [Display(Name = "الحي")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "هذا الحقل مطلوب ")]
        [StringLength(200)]
        public string neighborhood { set; get; }


        [Display(Name = "الشارع")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "هذا الحقل مطلوب ")]
        [StringLength(100)]
        public string street { set; get; }


        [Display(Name = "وصف لمعلم قريب")]
        [DataType(DataType.Text)]
        [StringLength(200)]
        public string adressLine { set; get; }


        [Display(Name = "صندوق بريد")]
        [DataType(DataType.Text)]
        [StringLength(5)]
        public string postcode { set; get; }



        //gps stuff


        public double latitude { set; get; }
        public double longitude { set; get; }
        public double latitudeDelta { set; get; }
        public double longitudeDelta { set; get; }






    }
}
