using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Tessera.Models;

namespace Tessera.ViewModels
{
    public class TicketFormViewModel
    {
        public IEnumerable<Group> Groups { get; set; }

        public IEnumerable<User> Users { get; set; }

        public IEnumerable<TicketStatus> TicketsStatus { get; set; }

        public IEnumerable<Priority> Priorities { get; set; }

        public Ticket Ticket { get; set; }

        public Comment Comment { get; set; }

        public IEnumerable<TicketAction> TicketActions { get; set; }

        public IEnumerable<Attachment> Attachments { get; set; }

        public HttpPostedFileBase[] Files { get; set; }      
        
    }
}