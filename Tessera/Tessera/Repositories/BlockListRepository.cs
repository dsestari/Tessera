using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tessera.Models;

namespace Tessera.Repositories
{
    public static class BlockListRepository
    {
        public static BlockList InsertBlockList(BlockList bList)
        {
            using (Context db = new Context())
            {
                db.Entry(bList).State = System.Data.Entity.EntityState.Added;

                db.SaveChanges();

                return bList;
            }
        }

        public static void DeleteBlockList(string email)
        {
            using (Context db = new Context())
            {
                var bList = db.BlockLists.Where(b => b.Username == email).ToList();

                foreach (var item in bList)
                {
                    db.BlockLists.Remove(item);

                }
                
                db.SaveChanges();
            }
        }
    }
}