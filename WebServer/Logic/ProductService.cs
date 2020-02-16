using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using WebServer.Model;

namespace WebServer.Logic
{
    public class ProductService : EntityService<Product>
    {
        protected override string insertCommand
        {
            get
            {
                return @"INSERT INTO [Product] (Name, Price, CompanyId)
              VALUES (@Name, @Price, @CompanyId)";
            }
        }

        protected override string updateCommand
        {
            get
            {
                return @"UPDATE [Product] SET Name = @Name, 
              Price = @Price, CompanyId = @CompanyId WHERE ID = @ID";
            }
        }

        protected override void AddParameters(SqlCommand command, Product entity)
        {
            command.Parameters.AddWithValue("@Name", entity.Name);
            command.Parameters.AddWithValue("@Price", entity.Price);
            command.Parameters.AddWithValue("@CompanyId", entity.CompanyId);
        }

        protected override Product LoadRow(IDataRecord row)
        {
            Product product = new Product();

            product.ID = Convert.ToInt32(row["ID"]);
            product.Name = Convert.ToString(row["Name"]);
            product.Price = Convert.ToDouble(row["Price"]);
            product.CompanyId = Convert.ToInt32(row["CompanyId"]);

            return product;
        }
    }
}
