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
    public class ReplyController : ApiController
    {
        public IHttpActionResult Get()
        {
            ReplyService cService = CreateReplyService();
            var replies = cService.GetReplies();
            return Ok(replies);
        }

        public IHttpActionResult Post(ReplyCreate reply)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var cService = CreateReplyService();
            if (!cService.CreateReply(reply))
            {
                return InternalServerError();
            }
            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            var cService = CreateReplyService();
            var comment = cService.GetReplyById(id);
            return Ok(comment);
        }

        public IHttpActionResult Put(ReplyEdit reply)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var cService = CreateReplyService();

            if (!cService.UpdateReply(reply))
                return InternalServerError();
            return Ok();
        }

        private ReplyService CreateReplyService()
        {
            var ownerId = Guid.Parse(User.Identity.GetUserId());
            var replyService = new ReplyService(ownerId);
            return replyService;
        }
    }
}
