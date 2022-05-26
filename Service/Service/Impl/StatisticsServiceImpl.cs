using DataLayer.Dto;
using DataLayer.Mapper;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Impl
{
    class StatisticsServiceImpl : StatisticsService
    {
        private readonly OrderDetailService orderDetailService;
        private readonly OrderService orderService;
        private readonly ProductService productService;

        public List<SaleProductAmountDto> StatisticSaleProductAmount(DateTime start, DateTime end)
        {
            var orderList = orderService.GetOrderByDate(start, end);
            List<SaleProductAmountDto> saleProductAmountDtoList = new List<SaleProductAmountDto>();
            foreach (var order in orderList)
            {
                var orderDetailList = orderDetailService.GetByOrderId(order.Id);
                foreach(var orderDetail in orderDetailList)
                {
                    SaleProductAmountDto saleProductAmountDto = new SaleProductAmountDto();
                    saleProductAmountDto.ProductId = orderDetail.ProductId;
                    saleProductAmountDto.ProductName = productService.GetById(orderDetail.ProductId).Name;
                    saleProductAmountDto.Amount = orderDetail.Quanity;

                    var res = saleProductAmountDtoList.Find(row => row.ProductId == saleProductAmountDto.ProductId);
                    if (res == null)
                        saleProductAmountDtoList.Add(saleProductAmountDto);
                    else
                        saleProductAmountDtoList.Find(row=>row.ProductId == saleProductAmountDto.ProductId).Amount += saleProductAmountDto.Amount;
                }
            }
            return saleProductAmountDtoList;
        }
    }
}
