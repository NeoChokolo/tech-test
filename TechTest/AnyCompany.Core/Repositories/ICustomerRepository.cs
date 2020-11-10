using AnyCompany.Model.DTOs;
using System.Collections.Generic;

namespace AnyCompany.Core.Repositories
{
    public interface ICustomerRepository
    {
        Customer Load(int customerId);
        List<CustomerOrders> CustomerOrders();
    }
}
