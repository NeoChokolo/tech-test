using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Model.DTOs
{
    [DataContract]
    public class CustomerOrders
    {
        /// <summary>
        /// 
        /// </summary>
        public CustomerOrders()
        {
            this.Orders = new List<Order>();
        }

        /// <summary>
        /// Customer information
        /// </summary>
        [DataMember(Name = "Customer")]
        public Customer Customer { get; set; }
      
        /// <summary>
        /// List of orders that belong to a customer
        /// </summary>
        public List<Order> Orders { get; set; }
    }
}
