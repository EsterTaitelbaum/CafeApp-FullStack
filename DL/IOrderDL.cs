using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IOrderDL
    {
        Task<Orders> createOrder(Orders order);
        Task<List<Orders>> getByUser(int id);
    }
}