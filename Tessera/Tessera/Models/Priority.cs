using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tessera.Models
{
    public class Priority
    {
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        [DisplayName("Name of the Priority")]
        public string Name { get; set; }
    }
}