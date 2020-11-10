using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnyCompany.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnyCompany.Model.DTOs;
using AnyCompany.Core.Repositories;
using AnyCompany.Infrastructure.Data.SQL;

namespace AnyCompany.Core.Services.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {

        private readonly IOrderService _orderService;

        public OrderServiceTests()
        {
            var customerRepo = new CustomerInstanceRepo();
            var orderRepo = new OrderRepository();
            _orderService = new OrderService(orderRepo,customerRepo);
        }

        /// <summary>
        /// Inserts new customer Order.
        /// </summary>
        [TestMethod()]
        public void PlaceOrderTest()
        {
            Order newOrder = new Order()
            {
                OrderId = 99,
                Amount = 100,
                VAT = 100
            };
            // Act
            var isOrderPlaced = _orderService.PlaceOrder(newOrder, 1).Result;

            Assert.AreEqual(true, isOrderPlaced);
        }
    }
}