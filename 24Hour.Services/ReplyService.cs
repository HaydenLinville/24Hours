using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _24Hour.Data;
using _24Hour.Models;

namespace _24Hour.Services
{
    public class ReplyService
    {
        private readonly Guid _ownerId;

        public ReplyService(Guid ownerId)
        {
            _ownerId = ownerId;
        }
        public bool CreateReply(ReplyCreate model)
        {
            var entity =
                new ReplyData()
                {
                    ReplyId = model.ReplyId,
                    Text = model.ReplyText,
                    CommentId = model.CommentId
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ReplyListItem> GetReplies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Replies
                    .Select(
                        e =>
                        new ReplyListItem
                        {
                            ReplyId = e.ReplyId,
                            ReplyText = e.Text
                        });
                return query.ToArray();
            }
        }

        public ReplyDetail GetReplyById(int replyID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Replies
                    .Single(e => e.ReplyId == replyID);
                return
                    new ReplyDetail
                    {
                        ReplyId = entity.ReplyId,
                        ReplyText = entity.Text
                    };
            }
        }

        public bool UpdateReply(ReplyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Replies
                    .Single(e => e.ReplyId == model.ReplyId);

                entity.Text = model.ReplyText;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteReply(int replyID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Replies
                    .Single(e => e.ReplyId == replyID);

                ctx.Replies.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
