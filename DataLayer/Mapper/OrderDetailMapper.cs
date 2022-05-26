using DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mapper
{
    class OrderDetailMapper : BaseMapper<OrderDetail>
    {
        protected List<OrderDetail> GetByOrderId(int orderId)
        {
            return db.OrderDetails.Where(row => row.OrderId == orderId).ToList();
        }
        
    }
}
