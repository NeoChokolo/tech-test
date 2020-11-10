using AnyCompany.Model.DTOs;
using System.Threading.Tasks;

namespace AnyCompany.Core.Services
{
    public interface IOrderService
    {

        /// <summary>
        /// Places customer order 
        /// </summary>
        /// <param name="order"></param>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<bool> PlaceOrder(Order order, int customerId);
    }
}
