using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Tessera.Models;

namespace Tessera.Repositories
{
    public class AttachmentRepository
    {
        public void SaveTicketAttachments(int idTicket, string path, string fileName, string extension)
        {
            using (Context db = new Context())
            {
                var attachments = db.Attachments.Where(a => a.TicketId == idTicket && a.Path == path).ToList();

                if (attachments.Count() == 0)
                {
                    var attach = new Attachment();

                    attach.TicketId = idTicket;
                    attach.Path = path;
                    attach.FileName = fileName;
                    attach.Extension = extension;
                    attach.CreatedDate = DateTime.Now;

                    db.Entry(attach).State = System.Data.Entity.EntityState.Added;

                    db.SaveChanges();
                }
            }
        }        

        public void DeleteAttachment(int idAttach)
        {
            using (Context db = new Context())
            {
                var attach = db.Attachments.SingleOrDefault(a => a.Id == idAttach);

                if (attach != null)
                {
                     db.Entry(attach).State = System.Data.Entity.EntityState.Deleted;

                     db.SaveChanges();
                }               
            }
        }
    }
}