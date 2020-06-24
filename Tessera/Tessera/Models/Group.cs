using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Tessera.Models
{
    public class Group
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(255)]
        [DisplayName("Name of the Group")]
        public string Name { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "The initials must contain at least 2 characters.")]
        [StringLength(8)]
        public string Initials { get; set; }

        [Required]
        public byte GroupStatusId { get; set; }

        public GroupStatus GroupStatus { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}