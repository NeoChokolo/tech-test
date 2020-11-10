using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Infrastructure.Configuration
{
    public class SQLDBManager
    {
        public static string CustomerConnectionString 
        {
            get 
            {
                return ConfigurationManager.AppSettings["CustomerDb"];
            }
        }

        public static string OrderConnectionString
        {
            get
            {
                return ConfigurationManager.AppSettings["OrderDb"];
            }
        }

        public static SqlConnection GetCustomerConnection()
        {
            var con = new SqlConnection(CustomerConnectionString);
            return con;
        }

        public static SqlConnection GetOrderConnection()
        {
            var con = new SqlConnection(OrderConnectionString);
            return con;
        }
    }

}
