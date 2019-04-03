﻿using System;
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
        public IEnumerable<tblUser> find(tblUser c)
        {
            var a = from s in dbSet
                    where s.User_Name == c.User_Name
                    select s;
            var filteredRows = dbSet.Where(p => p.User_Name == c.User_Name || p.User_Email == c.User_Email);
            
            return filteredRows;

        }

        public void remove(tblUser entity)
        {
            //dbSet.Find(entity);
        }


    }
}