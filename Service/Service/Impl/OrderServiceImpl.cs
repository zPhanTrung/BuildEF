using DataLayer.Entity;
using DataLayer.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.Impl
{
    internal class OrderServiceImpl : OrderService
    {
        OrderMapper _mapper;
        public OrderServiceImpl(OrderMapper mapper)
        {
            _mapper = mapper;
    }
        public List<Order> GetOrderByDate(DateTime start, DateTime end)
        {
            return _mapper.GetOrderByDate(start, end);
        }
    }
}
