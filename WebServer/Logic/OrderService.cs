using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WebServer.Model;

namespace WebServer.Logic
{
    public class OrderService : EntityService<Order>
    {
        protected override string insertCommand
        {
            get
            {
                return @"INSERT INTO [Order] (OrderID, CreateDate, ShipDate, Price)
              VALUES (@OrderID, @CreateDate, @ShipDate, @Price)";
            }
        }

        protected override string updateCommand
        {
            get
            {
                return @"UPDATE [Order] SET OrderID = @OrderID, CreateDate = @CreateDate, 
              ShipDate = @ShipDate, Price = @Price WHERE ID = @ID";
            }
        }

        protected override void AddParameters(SqlCommand command, Order entity)
        {
            command.Parameters.AddWithValue("@OrderID", entity.OrderID);
            command.Parameters.AddWithValue("@CreateDate", entity.CreateDate);
            command.Parameters.AddWithValue("@ShipDate", entity.ShipDate);
            command.Parameters.AddWithValue("@Price", entity.Price);
        }

        protected override Order LoadRow(IDataRecord row)
        {
            Order order = new Order();

            order.ID = Convert.ToInt32(row["ID"]);
            order.OrderID = Convert.ToString(row["OrderID"]);
            order.CreateDate = Convert.ToString(row["CreateDate"]);
            order.ShipDate = Convert.ToString(row["ShipDate"]);
            order.Price = Convert.ToDouble(row["Price"]);

            return order;
        }
    }
}
