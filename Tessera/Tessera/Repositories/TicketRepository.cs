using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Tessera.Models;
using System.Data;
using System.IO;
using Tessera.Properties;

namespace Tessera.Repositories
{
    public class TicketRepository
    {
        public int GetFirstAvaiableUserId(int groupId)
        {
            using (Context db = new Context())
            {
                var userIdList = db.Users.Where(u => u.GroupId == groupId).Select(u => new { u.Id }).ToList();

                var list = new List<TicketsPerUser>();

                foreach (var item in userIdList)
                {
                    var result = db.Tickets.Where(t => t.UserId == item.Id).ToList();
                    list.Add(new TicketsPerUser { userId = item.Id, count = result.Count() });
                }

                return list.OrderBy(l => l.count).Select(l => l.userId).First();
            }
        }

        public void PersistTicket(Ticket ticket, IEnumerable<HttpPostedFileBase> files)
        {
            using (Context db = new Context())
            {
                if (ticket.Id == 0)
                {
                    ticket.UpdateIn = ticket.OpeningDate;
                    ticket.TicketActionId = 1;
                    db.Tickets.Add(ticket);
                }
                else
                {
                    var ticketInDb = db.Tickets.Single(t => t.Id == ticket.Id);

                    ticketInDb.TicketStatusId = ticket.TicketStatusId;
                    ticketInDb.PriorityId = ticket.PriorityId;
                    ticketInDb.UpdateIn = DateTime.Today;
                    ticketInDb.GroupId = ticket.GroupId;
                    ticketInDb.UserId = ticket.UserId;
                }

                if (files != null)
                {
                    var aRep = new AttachmentRepository();

                    foreach (var file in files)
                    {
                        if (file != null)
                        {
                            file.SaveAs(Path.Combine(System.Web.HttpContext.Current.Server.MapPath(Settings.Default.UploadPath), file.FileName));

                            aRep.SaveTicketAttachments(ticket.Id, Path.Combine(Settings.Default.UploadPath, file.FileName), file.FileName, Path.GetExtension(file.FileName));
                        }
                        else
                            break;
                    }
                }
                db.SaveChanges();
            }
        }

        public Ticket GetTicketById(int id)
        {
            using (Context db = new Context())
            {
                return db.Tickets.SingleOrDefault(t => t.Id == id);
            }
        }
    }
}