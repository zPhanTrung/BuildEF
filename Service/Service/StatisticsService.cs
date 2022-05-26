using DataLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    interface StatisticsService
    {
        public List<SaleProductAmountDto> StatisticSaleProductAmount(DateTime start, DateTime end);
    }
}
