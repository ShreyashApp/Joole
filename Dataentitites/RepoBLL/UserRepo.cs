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
        private List<tblUser> dbSet => context.Set<tblUser>().ToList();

        /*
         * this method will query through a given list and find a row based on either the username or email and return
         * the row to the user as IEnumerable<tblUser>
         * return: IEnumerable<tblUser> - rows for all the users that matches either the username or email
         * arg: take a tblUser
         */
        public IEnumerable<tblUser> find(tblUser c)
        {
            var filteredRows = dbSet.Where(p => p.User_Name == c.User_Name || p.User_Email == c.User_Email);
            
            return filteredRows;

        }

        public tblUser find(int v)
        {
            throw new NotImplementedException();
        }

        public void remove(tblUser entity)
        {
            //dbSet.Find(entity);
        }


    }
}
