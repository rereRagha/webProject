using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEasyPrint.APIModels
{
    public class NewPrinterApiModel
    {

       
        public class Request { 

        public string prenterName { get; set; }
            //هل المكتبة تبيع ملازم ؟
        public bool isCourseMaterial { get; set; }
            //هل المكتبة تقدم خدمة الطباعة ؟
        public bool isService { get; set; }

        public string ownerId { get; set; }

        }

    }
}
