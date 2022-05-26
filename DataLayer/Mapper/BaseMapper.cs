using DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mapper
{
    class BaseMapper<TEntity> : IDisposable where TEntity : class
    {
        protected ShoppingDb db;
        protected BaseMapper()
        {
            db = new ShoppingDb();
        }

        public BaseMapper<TEntity> GetBaseMapper()
        {
            return this;
        }
        public TEntity GetById(int id)
        {
            return db.Set<TEntity>().Find(id);
        }

        public void Insert(TEntity entity)
        {
            db.AddRange(entity);
            db.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            db.Remove(entity);
            db.SaveChanges();
        }

        public List<TEntity> GetAll()
        {
            //foreach (var prop in db.GetType().GetProperties())
            //{
            //    var res = db.Model.GetEntityTypes().Where(t => t.Name == prop.Name).ToList();
            //    if(res.Count>0)
            //    {
            //        object value = prop.GetValue(res);
            //    }
            //}
            throw new NotImplementedException();
        }


        public void Uupdate(TEntity entity)
        {
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
