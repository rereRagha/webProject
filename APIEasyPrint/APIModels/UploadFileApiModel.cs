using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEasyPrint.APIModels
{
    public class UploadFileApiModel
    {
        public class Request
        {
            public string localFile { set; get; }
            public string fileName { set; get; }
            public IFormFile formFile { set; get;  }




        }

        public class Response
        {
           

        }
    }
}
