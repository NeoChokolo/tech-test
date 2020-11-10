using AnyCompany.Core.Repositories;
using AnyCompany.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Infrastructure.Data.SQL
{
    /// <summary>
    /// Static class wrapper
    /// </summary>
    public class CustomerInstanceRepo : ICustomerRepository
    {
        public List<CustomerOrders> CustomerOrders()
        {
            return CustomerRepository.LoadOrders();
        }

        public Customer Load(int customerId)
        {
            return CustomerRepository.Load(customerId);
        }
    }
}
