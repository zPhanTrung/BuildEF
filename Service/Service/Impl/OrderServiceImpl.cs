using DataLayer.Entity;
using DataLayer.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.Impl
{
    internal class OrderServiceImpl : BaseMapper<Order>, OrderService
    {
        public List<Order> GetOrderByDate(DateTime start, DateTime end)
        {
            return db.Orders.Where(row => row.OrderTime >= start && row.OrderTime <= end).ToList();
        }
    }
}
