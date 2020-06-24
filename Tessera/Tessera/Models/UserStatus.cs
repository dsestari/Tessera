using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Tessera.Models
{
    public class UserStatus
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(10)]
        [DisplayName("Name of the User Status")]
        public string Name { get; set; }
    }
}