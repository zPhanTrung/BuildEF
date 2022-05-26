using DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mapper
{
    internal class ProductMapperImpl:ProductMapper
    {
        BaseMapper<Product> _baseMapper;
        ShoppingDb db;
        public ProductMapperImpl(BaseMapper<Product> baseMapper)
        {
            _baseMapper = baseMapper;
            db = _baseMapper.GetDbContext();
        }

        public Product GetProductById(int id)
        {
            return _baseMapper.GetById(id);
        }
    }
}
