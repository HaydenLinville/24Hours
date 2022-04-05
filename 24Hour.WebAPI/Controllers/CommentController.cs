using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using _24Hour.Models;
using _24Hour.Services;
using Microsoft.AspNet.Identity;

namespace _24Hour.WebAPI.Controllers
{
    [Authorize]
    public class CommentController : ApiController
    {
        public IHttpActionResult Get()
        {
            CommentService cService = CreateCommentService();
            var comments = cService.GetComments();
            return Ok(comments);
        }

        public IHttpActionResult Post(CommentCreate comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var cService = CreateCommentService();
            if (!cService.CreateComment(comment))
            {
                return InternalServerError();
            }
            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            var cService = CreateCommentService();        
            var comment = cService.GetCommentById(id);
            return Ok(comment);
        }

        public IHttpActionResult Put(CommentEdit comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var cService = CreateCommentService();

            if (!cService.UpdateComment(comment))
                return InternalServerError();
            return Ok();
        }

        private CommentService CreateCommentService()
        {
            var ownerId = Guid.Parse(User.Identity.GetUserId());
            var commentService = new CommentService(ownerId);
            return commentService;
        }
    }
}
