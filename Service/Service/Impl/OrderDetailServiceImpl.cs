using DataLayer.Entity;
using DataLayer.Mapper;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("BuildEF")]
namespace Service.Impl
{
    class OrderDetailServiceImpl : OrderDetailMapper, OrderDetailService
    {
        List<OrderDetail> OrderDetailService.GetByOrderId(int orderId)
        {
            return GetByOrderId(orderId);
        }
    }
}
