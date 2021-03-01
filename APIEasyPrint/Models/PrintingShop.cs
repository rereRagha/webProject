using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIEasyPrint.Models
{
    public class PrintingShop
    {
        [Key]
        public Guid prentingShopId { get; set; }


        [Display(Name = "اسم المطبعة")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "هذا الحقل مطلوب ")]
        [StringLength(200)]
        public string prenterName { get; set; }

        [Display(Name = "خدمة بيع المطبوعات")]
        [Required(ErrorMessage = "هذا الحقل مطلوب ")]
        public bool isCourseMaterial { get; set; }

        [Display(Name = "خدمة طلبات الطباعة")]
        [Required(ErrorMessage = "هذا الحقل مطلوب ")]
        public bool isService { get; set; }





        [Display(Name = "خدمات التوصيل و أسعارها")]
        public DeliverOptions deliverOptions { get; set; }

        [Display(Name = "الموقع")]
        public Address address { get; set; }

        public List<ProblemReports> problemReports { set; get; }
        public List<PublicPromotionCode> publicPromotionCodes { set; get; }
        public List<PrivatePromotionCode> privatePromotionCodes { set; get; }
        public List<DeliveryDriver> deliveryDrivers { set; get; }

        
        [ForeignKey("OwnerFK")]
        public  string ownerId { get; set; }
        public ApplicationUser applicationUser { get; set; }




        public List<CourceMaterial> courceMaterial { set; get; }
        public List<ServiceDetails> serviceDetails { set; get; }
    }
}
