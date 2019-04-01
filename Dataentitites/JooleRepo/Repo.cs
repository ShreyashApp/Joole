using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JooleRepo
{
    public interface Repo<T> where T: class
    {

        IQueryable<T> entities { get; }
        void find(T entity);
        void remove(T entity);

    }
}