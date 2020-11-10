using AnyCompany.Core.Repositories;
using AnyCompany.Model.DTOs;
using System.Collections.Generic;

namespace AnyCompany.Core.Services
{
    public class CustomerService : ICustomerService
    {

        private readonly ICustomerRepository _customerRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        public CustomerService(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
        }

        /// <summary>
        /// Gets all customer orders
        /// </summary>
        /// <returns></returns>
        public List<CustomerOrders> CustomerOrders()
        {
            return _customerRepository.CustomerOrders();
        }

        /// <summary>
        /// Gets customer orders by customer Id.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public Customer Load(int customerId)
        {
            return _customerRepository.Load(customerId);
        }
    }
}
