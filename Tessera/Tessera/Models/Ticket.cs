using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Tessera.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Opening Date")]
        public DateTime OpeningDate { get; set; }

        [Required]
        [DisplayName("Due Date")]
        public DateTime DueDate { get; set; }

        [DisplayName("Update In")]
        public DateTime UpdateIn { get; set; }

        [Required]
        [StringLength(255)]
        [DisplayName("User Name")]
        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        [DisplayName("E-mail")]
        public string UserMail { get; set; }

        [DisplayName("Phone")]
        public string UserPhone { get; set; }

        public string Address { get; set; }

        [Required]
        [StringLength(100)]
        public string Summary { get; set; }
        
        [Required]
        [StringLength(5000)]
        public string Description { get; set; }

        [Required]
        [DisplayName("Status")]
        public byte TicketStatusId { get; set; }

        public TicketStatus TicketStatus { get; set; }

        [Required]
        [DisplayName("Group")]
        public byte GroupId { get; set; }

        public Group Group { get; set; }

        [Required]
        [DisplayName("User")]
        public int UserId { get; set; }

        public User User { get; set; }

        [Required]
        [DisplayName("Priority")]
        public int PriorityId { get; set; }
        
        public Priority Priority { get; set; }

        [Required]
        [DisplayName("Action")]
        public byte TicketActionId { get; set; }

        public TicketAction TicketAction { get; set; }
    }
}