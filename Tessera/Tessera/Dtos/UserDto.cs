using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tessera.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]        
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public byte GroupId { get; set; }

        public GroupDto Group { get; set; }

        [Required]
        public byte UserStatusId { get; set; }

        public UserStatusDto UserStatus { get; set; }
    }
}