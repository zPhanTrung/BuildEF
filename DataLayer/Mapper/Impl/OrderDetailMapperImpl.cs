using DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mapper
{
    class OrderDetailMapperImpl:OrderDetailMapper
    {
        BaseMapper<OrderDetail> _baseMapper;
        ShoppingDb db;
        public OrderDetailMapperImpl(BaseMapper<OrderDetail> baseMapper)
        {
            _baseMapper = baseMapper;
            db = _baseMapper.GetDbContext();
        }
        public List<OrderDetail> GetByOrderId(int orderId)
        {
            return db.OrderDetails.Where(row => row.OrderId == orderId).ToList();
        }
        
    }
}
