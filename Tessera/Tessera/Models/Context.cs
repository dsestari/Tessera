using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Tessera.Models
{
    public class Context : DbContext
    {
        public DbSet<UserStatus> UsersStatus { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<GroupStatus> GroupsStatus { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<TicketStatus> TicketsStatus { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<UserLog> UserLogs { get; set; }

        public DbSet<BlockList> BlockLists { get; set; }

        public DbSet<Priority> Priorities { get; set; }

        public DbSet<TicketAction> TicketActions { get; set; }

        public DbSet<Attachment> Attachments { get; set; }
    }
}