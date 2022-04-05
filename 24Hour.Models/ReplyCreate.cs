using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Models
{
    public class ReplyCreate
    {
        public int ReplyId { get; set; }
        [MaxLength(1000, ErrorMessage = "There are too many characters in this field. (Max 15")]
        [Required]
        public string ReplyText { get; set; }
        public override string ToString() => ReplyText;
        public int CommentId { get; set; }
        public string CommentTitle { get; set; }
    }
}
