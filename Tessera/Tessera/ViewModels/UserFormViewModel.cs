using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tessera.Models;

namespace Tessera.ViewModels
{
    public class UserFormViewModel
    {
        public IEnumerable<Group> Groups { get; set; }
        public IEnumerable<UserStatus> UserStatus { get; set; }
        public User User { get; set; }
    }
}