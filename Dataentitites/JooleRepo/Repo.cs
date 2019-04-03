﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JooleRepo
{
    public interface Repo<T> where T: class
    {

        IEnumerable<T> find(T v);
        void remove(T entity);

    }
}