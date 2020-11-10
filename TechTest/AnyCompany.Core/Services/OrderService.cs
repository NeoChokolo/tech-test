using AnyCompany.Core.Repositories;
using AnyCompany.Model.DTOs;
using System;
using System.Threading.Tasks;

namespace AnyCompany.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="orderRepository"></param>
        /// <param name="customerRepository"></param>
        public OrderService(IOrderRepository orderRepository, ICustomerRepository customerRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// Places customer order 
        /// </summary>
        /// <param name="order"></param>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<bool> PlaceOrder(Order order, int customerId)
        {
            try
            {
                Customer customer = _customerRepository.Load(customerId);

                if(customer==null)
                    return false;

                if (order.Amount == 0)
                    return false;

                if (customer.Country == "UK")
                    order.VAT = 0.2d;
                else
                    order.VAT = 0;

                return await _orderRepository.Save(order, customerId);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
