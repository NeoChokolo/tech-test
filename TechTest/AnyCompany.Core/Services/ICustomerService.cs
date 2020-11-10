using AnyCompany.Model.DTOs;
using System.Collections.Generic;

namespace AnyCompany.Core.Services
{
    public interface ICustomerService
    {
        /// <summary>
        /// Gets customer orders by customer Id.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Customer Load(int customerId);


        /// <summary>
        /// Gets all customer orders
        /// </summary>
        /// <returns></returns>
        List<CustomerOrders> CustomerOrders();
    }
}
