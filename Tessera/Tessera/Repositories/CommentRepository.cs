using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Linq;
using Tessera.Models;

namespace Tessera.Repositories
{
    public class CommentRepository
    {
        public IEnumerable<Comment> GetCommentsByTicketId(int? id)
        {
            using (Context db = new Context())
            {
                return db.Comments.Where(c => c.TicketId == id).ToArray();
            }
        }

        public void PersistComment(Comment comment)
        {
            using (Context db = new Context())
            {
                db.Entry(comment).State = System.Data.Entity.EntityState.Added;

                db.SaveChanges();
            }
        }
    }
}