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
    public interface IUser:Repo<tblUser>
    {
               
    }

    public class UserRepo : IUser
    {
        private DbContext context;

        public UserRepo(DbContext context)
        {
            this.context = context;
        }
        private IDbSet<tblUser> dbSet => context.Set<tblUser>();
        public IQueryable<tblUser> entities => dbSet;
        public tblUser find(int c)
        {
            var a = context.Set<tblUser>().Find(c);
            return a;
    
        }

        public void remove(tblUser entity)
        {
            dbSet.Find(entity);
        }

       
    }
}
