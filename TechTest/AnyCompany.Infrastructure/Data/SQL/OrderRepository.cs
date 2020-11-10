using AnyCompany.Core.Repositories;
using AnyCompany.Infrastructure.Configuration;
using AnyCompany.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace AnyCompany.Infrastructure.Data.SQL
{
    public class OrderRepository : IOrderRepository
    {

        /// <summary>
        /// Saves customer order details
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public async Task<bool> Save(Order order, int customerId)
        {
            using (SqlConnection con = SQLDBManager.GetOrderConnection())
            {
                try
                {
                    using (SqlCommand command = con.CreateCommand())
                    {
                        if (con.State == ConnectionState.Closed)
                            con.Open();

                        command.CommandType = CommandType.Text;
                        command.CommandText = "INSERT INTO Orders VALUES (@OrderId, @CustomerId, @Amount, @VAT)";

                        command.Parameters.AddWithValue("@OrderId", order.OrderId);
                        command.Parameters.AddWithValue("@CustomerId", customerId);
                        command.Parameters.AddWithValue("@Amount", order.Amount);
                        command.Parameters.AddWithValue("@VAT", order.VAT);

                        //implement async
                        command.ExecuteNonQuery();
                    }

                    return true;
                }
                catch (System.Exception ex)
                {
                    return false;
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
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<List<Order>> LoadOrders(int customerId)
        {
            List<Order> customerOrders = new List<Order>();

            using (SqlConnection con = SQLDBManager.GetOrderConnection())
            {
                using (SqlCommand command = con.CreateCommand())
                {
                    try
                    {
                        if (con.State == ConnectionState.Closed)
                            con.Open();

                        command.CommandType = CommandType.Text;
                        command.CommandText = "SELECT * FROM Orders WHERE CustomerId = " + customerId;

                        var reader = command.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                customerOrders.Add(new Order
                                {
                                    OrderId = Convert.ToInt32(reader["OrderId"].ToString()),
                                    Amount = Convert.ToDouble(reader["Amount"].ToString()),
                                    VAT = Convert.ToDouble(reader["VAT"].ToString())
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return customerOrders;
        }
    }
}
