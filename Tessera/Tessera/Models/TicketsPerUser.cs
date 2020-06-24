using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tessera.Models
{
    public class TicketsPerUser
    {
        public int userId { get; set; }

        public int count { get; set; }
    }
}