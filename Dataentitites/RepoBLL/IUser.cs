using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JooleRepo;
using Dataentitites;
using System.Data.Entity;

namespace RepoBLL
{
    interface IUser
    {

        
    }

    public class UserRepo : Repo<tblUser>,IUser
    {
        private readonly DbContext context;
        public UserRepo(DbContext context)
        {
            this.context = context;
        }

        
             private IDbSet<tblUser> dbSet => context.Set<tblUser>();
        public IQueryable<tblUser> entities => dbSet;
        public void find(tblUser entity)
        {
            dbSet.Find(entity);
        }

        public void remove(tblUser entity)
        {
            dbSet.Find(entity);
        }
    }
}
