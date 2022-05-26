using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entity
{
    class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quanity { get; set; }
        public decimal? Price { get; set; }
        public decimal? SubTotal { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
