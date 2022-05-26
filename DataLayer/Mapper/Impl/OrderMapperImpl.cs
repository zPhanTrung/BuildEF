using DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mapper
{
    class OrderMapperImpl : OrderMapper
    {
        BaseMapper<Order> _mapper;
        ShoppingDb db;
        public OrderMapperImpl(BaseMapper<Order> mapper)
        {
            _mapper = mapper;
            db = _mapper.GetDbContext();
        }

        public List<Order> GetOrderByDate(DateTime start, DateTime end)
        {
            var res = db.Orders.Where(row => row.OrderTime >= start && row.OrderTime <= end).ToList();
            return res;
        }
    }
}
