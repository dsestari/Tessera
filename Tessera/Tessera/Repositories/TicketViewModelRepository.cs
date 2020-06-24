using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tessera.ViewModels;
using System.Data.Entity;
using Tessera.Models;

namespace Tessera.Repositories
{
    public class TicketViewModelRepository
    {
        public TicketFormViewModel GetTicketInfoByUserName(string userName)
        {
            using (Context db = new Context())
            {
                var userRep = new UserRepository();

                var user = userRep.GetUserByName(userName);

                if (user != null)
                {
                    var viewModel = new TicketFormViewModel
                          {
                              Ticket = new Ticket(),
                              TicketsStatus = db.TicketsStatus.Where(t => t.Id == 1).ToList(),
                              Priorities = db.Priorities.ToList(),
                              Users = db.Users.Where(u => u.Id == user.Id).ToList(),
                              Groups = db.Groups.Where(g => g.Id == user.GroupId).ToList()
                          };

                    viewModel.Ticket.OpeningDate = DateTime.Now;
                    viewModel.Ticket.DueDate = DateTime.Now;
                    viewModel.Ticket.TicketActionId = 1;

                    return viewModel;
                }
                else
                {
                    return null;
                }
            }
        }

        public TicketFormViewModel GetTicketInfoByUserAndGroupId(Ticket ticket)
        {
            using (Context db = new Context())
            {
                var viewModel = new TicketFormViewModel
                      {
                          Ticket = ticket,
                          TicketsStatus = db.TicketsStatus.ToList(),
                          Priorities = db.Priorities.ToList(),
                          Users = db.Users.Where(u => u.Id == ticket.UserId).ToList(),
                          Groups = db.Groups.Where(g => g.Id == ticket.GroupId).ToList()
                      };

                return viewModel;
            }
        }

        public TicketFormViewModel GetTicketInfoById(int id)
        {
            using (Context db = new Context())
            {
                var ticketRep = new TicketRepository();

                var ticket = ticketRep.GetTicketById(id);

                if (ticket != null)
                {
                    var viewModel = new TicketFormViewModel
                    {
                        Ticket = ticket,
                        TicketsStatus = db.TicketsStatus.ToList(),
                        Priorities = db.Priorities.ToList(),
                        Users = db.Users.Where(u => u.Id == ticket.UserId).ToList(),
                        Groups = db.Groups.Where(g => g.Id == ticket.GroupId).ToList(),
                        TicketActions = db.TicketActions.ToList(),
                        Attachments = db.Attachments.Where(a => a.TicketId == ticket.Id).ToList()
                    };

                    return viewModel;
                }
                else
                    return null;
            }
        }

        public TicketFormViewModel GetTicketInfoByAction(Ticket ticket)
        {
            using (Context db = new Context())
            {
                var viewModel = new TicketFormViewModel
                {
                    Ticket = ticket,
                    TicketsStatus = db.TicketsStatus.ToList(),
                    Priorities = db.Priorities.ToList(),
                    Users = db.Users.ToList(),
                    Groups = db.Groups.ToList(),
                    TicketActions = db.TicketActions.Where(t => t.Id != 1).ToList()
                };
                return viewModel;
            }
        }        
    }
}