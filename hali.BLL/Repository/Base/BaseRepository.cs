using hali.DAL.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace hali.BLL.Repository.Base
{
    public class BaseRepository<T> where T:class
    {
        private IsciDBEntities db;
        protected DbSet<T> table;

        public BaseRepository()
        {
            db = new IsciDBEntities();
            table = db.Set<T>();
        }


        public int Save()
        {
            return db.SaveChanges();
        }

        public virtual void Insert(T entity)
        {
            table.Add(entity);
            Save();
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return table.Any(predicate);
        }

        public List<T> GetAll()
        {
            return table.ToList();
        }

        public T Find(long ID)
        {
            return table.Find(ID);
        }

        public void SuperDelete(long ID)
        {
            T entity = table.Find(ID);
            table.Remove(entity);
            Save();
        }
    }

    
}

