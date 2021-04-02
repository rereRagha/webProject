using System;
using System.ComponentModel.DataAnnotations;

namespace APIEasyPrint.Models
{
    public class Status
    {
        [Key]
        public Guid StatusId { set; get; }
        public int StatusNo { set; get; }

        public string statusName { set; get; }
    }
}