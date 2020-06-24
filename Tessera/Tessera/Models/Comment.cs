using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Security;

namespace Tessera.Models
{
    public class Comment
    {        
        public int Id { get; set; }
        
        [StringLength(5000)]
        [Column(TypeName = "ntext")]
        [DisplayName("Comment")]
        [Required]
        public string CommentText { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public int TicketId { get; set; }             
      
        [Required]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }       
    }
}