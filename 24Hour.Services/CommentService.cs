using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _24Hour.Data;
using _24Hour.Models;

namespace _24Hour.Services
{
    public class CommentService
    {
        private readonly Guid _ownerId;

        public CommentService(Guid ownerId)
        {
            _ownerId = ownerId;
        }
         public bool CreateComment(CommentCreate model)
        {
            var entity =
                new Comment()
                {
                    CommentId = model.CommentId,
                    CommentText = model.CommentText,
                    ReplyId = model.ReplyId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CommentListItem> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Comments
                    .Select(
                        e =>
                        new CommentListItem
                        {
                            CommentId = e.CommentId,
                            CommentText = e.CommentText
                        });
                return query.ToArray();
            }
        }

        public CommentDetail GetCommentById(int commentID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Comments
                    .Single(e => e.CommentId == commentID);
                return
                    new CommentDetail
                    {
                        CommentId = entity.CommentId,
                        CommentText = entity.CommentText
                    };
            }
        }

        public bool UpdateComment(CommentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Comments
                    .Single(e => e.CommentId == model.CommentId);

                entity.CommentText = model.CommentText;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteCategory(int commentID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Comments
                    .Single(e => e.CommentId == commentID);

                ctx.Comments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
