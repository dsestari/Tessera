using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tessera.Dtos
{
    public class GroupStatusDto
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(10)]        
        public string Name { get; set; }
    }
}