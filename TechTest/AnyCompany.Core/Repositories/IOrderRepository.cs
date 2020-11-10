using AnyCompany.Model.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnyCompany.Core.Repositories
{
    public interface IOrderRepository
    {
        Task<bool> Save(Order order, int customerId);

        Task<List<Order>> LoadOrders(int customerId);
    }
}
