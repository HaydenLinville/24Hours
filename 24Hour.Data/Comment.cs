using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Data
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [Required]
        public string CommentText { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [ForeignKey(nameof(PostId))]
        public int PostId { get; set; }
        public virtual List<Replies> Replies { get; set; } = new List<Replies>();

    }
}
