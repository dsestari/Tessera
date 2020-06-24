using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tessera.Dtos
{
    public class TicketStatusDto
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(25)]       
        public string Name { get; set; }
    }
}