using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Tessera.Models
{
    public class TicketStatus
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(25)]
        [DisplayName("Name of the Ticket Status")]
        public string Name { get; set; }
    }
}