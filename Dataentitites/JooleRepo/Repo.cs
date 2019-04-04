using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JooleRepo
{
    public interface Repo<T> where T: class
    {
        T find(int v);

        IEnumerable<T> find(T v);
        void remove(T entity);

    }
}