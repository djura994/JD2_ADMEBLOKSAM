using BookingApp.Models;
using ModelClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace BookingApp.Controllers
{
    public class CommentsController : ApiController
    {
        private BAContext db = new BAContext();

        // GET: api/Comments
        public IQueryable<Comment> GetComments()
        {
            return db.comments;
        }

        // GET: api/Comments/5
        [ResponseType(typeof(Comment))]
        public IHttpActionResult GetComment(int id)
        {
            Comment comment = db.comments.Find(id);
            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }

        // PUT: api/Comments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutComment(int id, Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comment.Id)
            {
                return BadRequest();
            }

            db.Entry(comment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Comments
        [ResponseType(typeof(Comment))]
        public IHttpActionResult PostComment(Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.comments.Add(comment);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = comment.Id }, comment);
        }

        // DELETE: api/Comments/5
        [ResponseType(typeof(Comment))]
        public IHttpActionResult DeleteComment(int id)
        {
            Comment comment = db.comments.Find(id);
            if (comment == null)
            {
                return NotFound();
            }

            db.comments.Remove(comment);
            db.SaveChanges();

            return Ok(comment);
        }
        private bool CommentExists(int id)
        {
            return db.comments.Count(e => e.Id == id) > 0;
        }
    }
}
