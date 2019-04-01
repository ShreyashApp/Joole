using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RepoBLL
{

    interface unitofwork
    {
        IUser users { get; } 
    }

    public class UnitofWork:unitofwork
    {
        private readonly DbContext context;

        UnitofWork(DbContext context)
        {
            this.context = context;
        }

        IUser unitofwork.users => new UserRepo(context);
    }
}