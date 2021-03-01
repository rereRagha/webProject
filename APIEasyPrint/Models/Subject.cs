using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIEasyPrint.Models
{
    public class Subject
    {
        [Key]
        public Guid subjectId { get; set; }


        [Display(Name = "اسم التصنيف")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "هذا الحقل مطلوب ")]
        [StringLength(200)]
        public string subjectName { get; set; }

        public List<CourceMaterial> courceMaterials { get; set; }

    }
}
