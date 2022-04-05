using _24Hour.Data;
using _24Hour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Services
{
    public class PostService
    {
        private readonly Guid _userId;
        public PostService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePost(PostCreate model)
        {

            var entity = new Post()
            {
                OwnerId = _userId,
                Title = model.Title,
                Text = model.Text
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() >= 1;
            }

        }

        public IEnumerable<PostListItem> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Posts.Where(e => e.OwnerId == _userId).Select(e => new PostListItem { PostId = e.NoteId, Title = e.Title });
                return query.ToArray();
            }
        }

        public PostDetail GetPostById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Posts.Single(e => e.PostId == id && e.OwnerId == _userId);
                return
                    new PostDetail
                    {
                        PostId = entity.PostId,
                        Title = entity.Title,
                        Text = entity.Text,
                        CommentId = entity.CommentId
                    };
            }

        }
        
        public bool UpdatePost(PostEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Posts.Single(e => e.PostId == model.PostId && e.OwnerId == _userId);

                entity.Title = model.Title;
                entity.Text = model.Text;

                return ctx.SaveChanges() >= 1;
            }
        }

        public bool DeletePost(int postId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Posts.Single(e => e.PostId == postId && e.OwnerId == _userId);

                ctx.Posts.Remove(entity);

                return ctx.SaveChanges() >= 1;
            }
        }

    }
}
