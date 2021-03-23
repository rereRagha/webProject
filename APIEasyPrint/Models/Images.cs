using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIEasyPrint.Models
{
    public class Images
    {
        [Key]
        public Guid ImgId { set; get; }
        public byte[] ImgeBytes { set; get; }
        public double siz { set; get;  }

        // the item that connected to it (printer or a material )
        public string ItemId { set; get; }
    }
}
