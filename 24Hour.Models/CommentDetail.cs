using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _24Hour.Data;

namespace _24Hour.Models
{
    public class CommentDetail
    {
        [Display(Name ="Comment ID")]
        public int CommentId { get; set; }
        [Display(Name = "Comment Text")]
        public string CommentText { get; set; }
        public ICollection<ReplyData> Reply { get; set; }
    }
}
