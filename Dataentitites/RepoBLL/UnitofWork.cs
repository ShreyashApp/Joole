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
        IProducts prods { get; }
        IManufacturer manu { get; }

        IProductType prodtype { get; }
    }

    public class UnitofWork: DbContext,Iunitofwork
    {
        private readonly DbContext context;

        
        public UnitofWork(DbContext context)
        {
            this.context = context;
        }

        public IUser users => new UserRepo(context);
        public IProducts prods => new ProductsRepo(context);

        public IManufacturer manu => new ManufacturerRepo(context);

        public IProductType prodtype => new ProductTypeRepo(context);
    }
}