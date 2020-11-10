using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnyCompany.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnyCompany.Core.Repositories;
using AnyCompany.Infrastructure.Data.SQL;

namespace AnyCompany.Core.Services.Tests
{
    [TestClass()]
    public class CustomerServiceTests
    {
        private readonly ICustomerService _customerService;

        public CustomerServiceTests()
        {
            var customerRepo = new CustomerInstanceRepo();
            _customerService = new CustomerService(customerRepo);
        }
        
        /// <summary>
        /// Gets all customers and their orders.
        /// </summary>
        [TestMethod()]
        public void CustomerOrdersTest()
        {
            var results = _customerService.CustomerOrders();

            Assert.IsTrue(results.Count > 0,"No Customer orders found");
        }

        /// <summary>
        /// Gets customer orders by customer Id.
        /// </summary>
        [TestMethod()]
        public void LoadCustomerOrdersTest()
        {
            var results = _customerService.Load(1);
            Assert.IsTrue(results != null, string.Format("No Customer orders found for customer Id : {0}", 1));

        }
    }
}