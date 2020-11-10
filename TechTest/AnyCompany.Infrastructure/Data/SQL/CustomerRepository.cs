using AnyCompany.Core.Repositories;
using AnyCompany.Infrastructure.Configuration;
using AnyCompany.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AnyCompany.Infrastructure.Data.SQL
{
    public static class CustomerRepository
    {
        private static readonly IOrderRepository orderRepository = new OrderRepository();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public static Customer Load(int customerId)
        {

            using (SqlConnection con = SQLDBManager.GetCustomerConnection())
            {
                try
                {
                    using (SqlCommand command = con.CreateCommand())
                    {
                        if (con.State == ConnectionState.Closed)
                            con.Open();

                        command.CommandType = CommandType.Text;
                        command.CommandText = "SELECT * FROM Customer WHERE CustomerId = " + customerId;

                        var reader = command.ExecuteReader();

                        if(reader.HasRows)
                        {
                            reader.Read();

                            var customer = new Customer
                            {
                                Name = reader["Name"].ToString(),
                                DateOfBirth = DateTime.Parse(reader["DateOfBirth"].ToString()),
                                Country = reader["Country"].ToString()
                            };
                            return customer;
                        }
                        else
                        {
                            return null;
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<CustomerOrders> LoadOrders()
        {
            List<CustomerOrders> customerOrders = new List<CustomerOrders>();

            using (SqlConnection con = SQLDBManager.GetCustomerConnection())
            {
                using (SqlCommand command = con.CreateCommand())
                {
                    try
                    {

                        if (con.State == ConnectionState.Closed)
                            con.Open();

                        command.CommandType = CommandType.Text;
                        command.CommandText = "SELECT * FROM Customer";

                        var reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var order = new CustomerOrders
                                {
                                    Customer = new Customer
                                    {
                                        Name = reader["Name"].ToString(),
                                        Country = reader["Country"].ToString(),
                                        DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"].ToString())
                                    }
                                };
                                order.Orders.AddRange(orderRepository.LoadOrders(Convert.ToInt32(reader["CustomerId"].ToString())).Result);
                                customerOrders.Add(order);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }

            return customerOrders;
        }
    }
}
