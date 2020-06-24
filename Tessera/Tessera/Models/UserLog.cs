using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tessera.Models
{
    public class UserLog
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public DateTime DataLog { get; set; }

        public string Description { get; set; }
    }
}