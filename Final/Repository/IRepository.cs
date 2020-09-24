using Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Final.Repository
{
    interface IRepository<T> where T : class
    {
        T GetByName(string uname);

        List<T> GetAll();

    }
}