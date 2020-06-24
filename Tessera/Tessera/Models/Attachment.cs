using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tessera.Models
{
    public class Attachment
    {
        public int Id { get; set; }

        [Required]
        public string Path { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        public int TicketId { get; set; }

        public string FileName { get; set; }

        public string Extension { get; set; }        
    }
}