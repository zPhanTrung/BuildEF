using DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mapper
{
    class BaseMapperImpl<TEntity> : BaseMapper<TEntity>, IDisposable where TEntity : class
    {
        private ShoppingDb db;
        public BaseMapperImpl(ShoppingDb dbContext)
        {
            db = dbContext;
        }

        public ShoppingDb GetDbContext()
        {
            return db;
        }

        public BaseMapperImpl<TEntity> GetBaseMapper()
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

            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();

        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
