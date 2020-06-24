using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Security;
using Tessera.Utilities;

namespace Tessera.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name is required.")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The e-mail is required.")]
        [EmailAddress(ErrorMessage = "The e-mail is not valid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The password is required.")]
        [MinLength(8, ErrorMessage = "The password must contain at least 8 characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }              

        [Required(ErrorMessage = "The group is required.")]
        [DisplayName("Group")]
        public byte GroupId { get; set; }

        public Group Group { get; set; }

        [DisplayName("Status")]
        [Required(ErrorMessage = "The status is required.")]
        public byte UserStatusId { get; set; }

        public UserStatus UserStatus { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        public bool FirstAccess { get; set; }

        public User()
        {
            RegistrationDate = DateTime.Now;
            FirstAccess = true;
            Password = Helper.Encode(Membership.GeneratePassword(8, 0));            
        }                
    }
}