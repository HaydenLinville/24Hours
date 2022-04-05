using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Models
{
    public class CommentCreate
    {
        public int CommentId { get; set; }
        [MaxLength(1000, ErrorMessage = "There are too many charcters int this field. (Max 15")]
        [Required]
        public string CommentText { get; set; }
        public override string ToString() => CommentText;
        public int PostId { get; set; }
        public string PostTitle { get; set; }
    }
}
