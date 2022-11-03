using DL;
using Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class OrderBL : IOrderBL
    {
        IOrderDL orderDL;
        ILogger<OrderBL> _logger;
        CoffeeShopContext _CoffeeShopContext;

        public OrderBL(IOrderDL orderDL, ILogger<OrderBL> logger, CoffeeShopContext CoffeeShopContext)
        {
            this.orderDL = orderDL;
            _logger = logger;
            _CoffeeShopContext = CoffeeShopContext;
        }

        public async Task<Orders> createOrder(Orders order)
        {
            double sum = 0;
            //foreach (var item in order.OrderItems)
            //{
            //    Products p = _CoffeeShopContext.Products.Where(prod => prod.ProductId.Equals(item.ProductId)).FirstOrDefault();
            //    sum += p.Price * item.Quantity;
            //}
            //if (sum != order.OrderSum)
            //{
            //    _logger.LogError("Amount incompatible, maybe someone is trying to steal you!!!");
            //}
            order.OrderSum = sum;
            return await orderDL.createOrder(order);
        }

        public async Task<List<Orders>> getByUser(int id)
        {
            return await orderDL.getByUser(id);
        }


    }
}
