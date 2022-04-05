using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Models
{
    public class ReplyDetail
    {
        [Display(Name = "Reply ID")]
        public int ReplyId { get; set; }
        [Display(Name = "Reply Text")]
        public string ReplyText { get; set; }
    }
}
