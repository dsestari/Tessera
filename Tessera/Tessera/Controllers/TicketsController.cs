using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tessera.Models;
using Tessera.ViewModels;
using System.Data.Entity;
using System.Threading.Tasks;
using PusherServer;
using System.Net;
using Tessera.Repositories;
using System.IO;
using Tessera.Properties;

namespace Tessera.Controllers
{
    public class TicketsController : Controller
    {
        private Context _context;

        public TicketsController()
        {
            _context = new Context();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult New()
        {
            var ticketRep = new TicketViewModelRepository();

            var viewModel = ticketRep.GetTicketInfoByUserName(User.Identity.Name);

            if (viewModel != null)
            {
                return View("TicketForm", viewModel);
            }
            else
                return RedirectToAction("Login", "Users");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Ticket ticket, IEnumerable<HttpPostedFileBase> files)
        {
            if (!ModelState.IsValid)
            {
                var ticketViewRep = new TicketViewModelRepository();

                return View("TicketForm", ticketViewRep.GetTicketInfoByUserAndGroupId(ticket));
            }

            var ticketRep = new TicketRepository();

            ticketRep.PersistTicket(ticket, files);

            var ticketViewModelRep = new TicketViewModelRepository();

            return View("TicketActionForm", ticketViewModelRep.GetTicketInfoById(ticket.Id));
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var ticketViewRep = new TicketViewModelRepository();

            var viewModel = ticketViewRep.GetTicketInfoById(id);

            if (viewModel == null)
                return HttpNotFound();

            return View("TicketForm", viewModel);
        }

        public ActionResult Comments(int? id)
        {
            var commentRep = new CommentRepository();

            var comments = commentRep.GetCommentsByTicketId(id);

            return Json(comments, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> Comment(Comment data)
        {
            if (data.CommentText != null)
            {
                data.UserId = (int)Session["UserId"];
                data.CreatedDate = DateTime.Now;

                var commentRep = new CommentRepository();
                commentRep.PersistComment(data);
            }

            var options = new PusherOptions();
            options.Cluster = Settings.Default.PusherServerCluster;

            var pusher = new Pusher(Settings.Default.PusherServerAppId, 
                                    Settings.Default.PusherServerAppKey, 
                                    Settings.Default.PusherServerAppSecret, options);
            ITriggerResult result = await pusher.TriggerAsync("asp_channel", "asp_event", data);

            return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString());
        }

        [Authorize]
        public ActionResult Action(Ticket ticket)
        {
            if (ticket == null)
                return HttpNotFound();

            var ticketRep = new TicketViewModelRepository();

            return View("TicketActionForm", ticketRep.GetTicketInfoByAction(ticket));
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Keep(Ticket ticket, IEnumerable<HttpPostedFileBase> files)
        {
            if (ticket.UserId == 0 && ticket.TicketActionId == 2)
            {
                var tRep = new TicketRepository();

                ticket.UserId = tRep.GetFirstAvaiableUserId(ticket.GroupId);
            }

            if (!ModelState.IsValid)
            {
                var ticketViewModelRep = new TicketViewModelRepository();

                return View("TicketActionForm", ticketViewModelRep.GetTicketInfoByAction(ticket));
            }

            var ticketRep = new TicketRepository();
            ticketRep.PersistTicket(ticket, files);

            return RedirectToAction("Index", "Tickets");
        }

        [HttpPost]
        [Authorize]
        public ActionResult GetUsersByGroup(int groupId)
        {
            var userRep = new UserRepository();

            var usersList = userRep.GetUsersByGroup(groupId);

            SelectList userList = new SelectList(usersList, "Id", "Name", 0);

            return Json(userList);
        }

        [HttpPost]
        [Authorize]
        public ActionResult RemoveAttach(int attachId)
        {
            var attachRep = new AttachmentRepository();

            attachRep.DeleteAttachment(attachId);

            return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString());
        }
    }
}