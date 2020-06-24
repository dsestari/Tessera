using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tessera.Models;

namespace Tessera.Repositories
{
    public static class UserLogRepository
    {
        public static UserLog InsertUserLog(UserLog userLog)
        {
            using (Context db = new Context())
            {
                db.Entry(userLog).State = System.Data.Entity.EntityState.Added;

                db.SaveChanges();

                return userLog;
            }
        }
    }
}