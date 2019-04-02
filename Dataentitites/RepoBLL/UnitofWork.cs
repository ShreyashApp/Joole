using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RepoBLL
{

    interface Iunitofwork
    {
        IUser users { get;  } 
    }

    public class UnitofWork: DbContext,Iunitofwork
    {
        private readonly DbContext context;

        
        public UnitofWork(DbContext context)
        {
            this.context = context;
        }

        public IUser users => new UserRepo(context);
    }
}