﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entity
{
    internal class Order
    {
        public int Id { get; set; }
        public int ProductQuanity { get; set; }
        public DateTime OrderTime { get; set; }
        public int GrandTotal { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}