using Final.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Final.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected FinalDataContext context;
        public Repository()
        {
            this.context = new FinalDataContext();
        }

        public T GetByName(string uname)
        {
            return context.Set<T>().Find(uname);
        }

        public List<T> GetAll()
        {

            return context.Set<T>().ToList();
        }

        public T GetByID(int id)
        {
            return context.Set<T>().Find(id);
        }
        public T GetByEmail(string email)
        {
            return context.Set<T>().Find(email);
        }

        public void Insert(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Set<T>().Remove(GetByID(id));
            context.SaveChanges();
        }

        public void Edit(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

    }
}