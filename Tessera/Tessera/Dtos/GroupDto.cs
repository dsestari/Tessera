using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tessera.Dtos
{
    public class GroupDto
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(255)]        
        public string Name { get; set; }

        [Required]        
        [StringLength(8)]
        public string Initials { get; set; }

        [Required]
        public byte GroupStatusId { get; set; }

        public GroupStatusDto GroupStatus { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}