using DataLayer.Entity;
using DataLayer.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("BuildEF")]

namespace Service.Service
{
    interface OrderDetailService
    {
        public List<OrderDetail> GetByOrderId(int orderId);
    }
}
