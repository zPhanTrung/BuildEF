using DataLayer.Entity;
using DataLayer.Mapper;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Service.Impl
{
    class OrderDetailServiceImpl : OrderDetailService
    {
        OrderDetailMapper _mapper;
        public OrderDetailServiceImpl(OrderDetailMapper mapper)
        {
            _mapper = mapper;
        }

        List<OrderDetail> OrderDetailService.GetByOrderId(int orderId)
        {
            return _mapper.GetByOrderId(orderId);
        }
    }
}
