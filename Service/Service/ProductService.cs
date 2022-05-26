using DataLayer.Entity;
using DataLayer.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    interface ProductService
    {
        public Product GetById(int id);
    }
}
