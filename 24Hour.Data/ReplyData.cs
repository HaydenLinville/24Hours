using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Data
{
    public class ReplyData
    {
            
        [Key]
        public int ReplyId { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [ForeignKey(nameof(Comment))]
        public int CommentId { get; set; }
        public virtual CommentData Comment { get; set; }

    }
}
