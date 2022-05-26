using DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mapper
{
    internal interface BaseMapper<TEntity>
    {
        public ShoppingDb GetDbContext();

        public TEntity GetById(int id);

        public void Insert(TEntity entity);

        public void Delete(TEntity entity);

        public List<TEntity> GetAll();

        public void Update(TEntity entity);
    }
}
