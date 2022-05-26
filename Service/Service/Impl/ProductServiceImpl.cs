using DataLayer.Entity;
using DataLayer.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service.Impl
{
    class ProductServiceImpl : ProductService
    {
        ProductMapper _mapper;
        public ProductServiceImpl(ProductMapper mapper)
        {
            _mapper = mapper;
        }

        public Product GetProductById(int id)
        {
            return _mapper.GetProductById(id);
        }
    }
}
