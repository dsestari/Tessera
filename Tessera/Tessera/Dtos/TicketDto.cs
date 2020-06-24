using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Tessera.Models;

namespace Tessera.Dtos
{
    public class TicketDto
    {
        public int Id { get; set; }

        [Required]        
        public DateTime OpeningDate { get; set; }

        [Required]       
        public DateTime DueDate { get; set; }
        
        public DateTime UpdateIn { get; set; }

        [Required]
        [StringLength(255)]        
        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)] 
        public string UserMail { get; set; }
        
        public string UserPhone { get; set; }

        public string Address { get; set; }

        [Required]
        [StringLength(100)]
        public string Summary { get; set; }

        [Required]
        [StringLength(5000)]
        public string Description { get; set; }

        [Required]        
        public byte TicketStatusId { get; set; }

        public TicketStatusDto TicketStatus { get; set; }

        [Required]       
        public byte GroupId { get; set; }

        public GroupDto Group { get; set; }

        [Required]        
        public int UserId { get; set; }

        public UserDto User { get; set; }

        [Required]
        public byte PriorityId { get; set; }

        public PriorityDto Priority { get; set; }

        [Required]
        public byte TicketActionId { get; set; }

        public TicketActionDto TicketAction { get; set; }
    }
}