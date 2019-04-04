using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JooleRepo;
using Dataentitites;
using System.Data.Entity;

namespace RepoBLL
{

    public interface IProducts : Repo<tblProduct>
    {

    }

    public class ProductsRepo : IProducts
    {

        private DbContext context;

        public ProductsRepo(DbContext context)
        {
            this.context = context;
        }

        private DbSet<tblProduct> dbset => context.Set<tblProduct>();
        IQueryable<tblProduct> Repo<tblProduct>.entities => dbset;

        public void remove(tblProduct entity)
        {
            throw new NotImplementedException();
        }

        public tblProduct find(int v)
        {
            var a = dbset.Find(v);
            return a;
        }
    }
}