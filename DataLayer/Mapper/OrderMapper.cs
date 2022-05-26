using DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Mapper
{
    internal interface OrderMapper
    {
        public List<Order> GetOrderByDate(DateTime start, DateTime end);
    }
}
