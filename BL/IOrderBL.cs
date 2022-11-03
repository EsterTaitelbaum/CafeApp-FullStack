using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IOrderBL
    {
        Task<Orders> createOrder(Orders order);
        Task<List<Orders>> getByUser(int id);
    }
}