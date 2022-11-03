using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class OrderDL : IOrderDL
    {

        CoffeeShopContext CoffeeShopContext;

        public OrderDL(CoffeeShopContext CoffeeShopContext)
        {
            this.CoffeeShopContext = CoffeeShopContext;
        }

        public async Task<Orders> createOrder(Orders order)
        {
            await CoffeeShopContext.Orders.AddAsync(order);
            await CoffeeShopContext.SaveChangesAsync();
            return order;
        }

        public async Task<List<Orders>> getByUser(int id)
        {
            return await CoffeeShopContext.Orders.Where(data => data.UserId.Equals(id)).ToListAsync();
        }

    }
}
