using System;
using System.Data;
using Dapper;

namespace BestBuyBestPractices
{
    public class DapperProductRepository : iProductRepository
    {

        private readonly IDbConnection _connection;

        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO products (Name, Price, CategoriesID) " +
                "VALUES (@name, @price, @categoryID);",
                new { name = name, price = price, categoryID = categoryID });

        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM products;");
        }

        public void UpdateProduct(int productID, string updatedName)
        {
            _connection.Execute("UPDATE products SET Name = @updatedName WHERE productID = @productID;",
                new { productID = productID, updatedName = updatedName });
        }
    }
}

