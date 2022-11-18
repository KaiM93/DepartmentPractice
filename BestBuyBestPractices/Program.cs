using BestBuyBestPractices;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

string connString = config.GetConnectionString("DefaultConnection");

IDbConnection conn = new MySqlConnection(connString);

var repo = new DapperProductRepository(conn);

Console.WriteLine("What is the name of your prudct?");
var prodName = Console.ReadLine();

Console.WriteLine("What is the price?");
var prodPrice = double.Parse(Console.ReadLine());

Console.WriteLine("What is the category ID");
var prodCat = int.Parse(Console.ReadLine());

repo.CreateProduct(prodName, prodPrice, prodCat);

var prodList = repo.GetAllProducts();

foreach (var prod in prodList)
{
    Console.WriteLine($"{prod.ProductID} - {prod.Name}");
}

Console.WriteLine("What is the product you want to update ?");
var prodID = int.Parse(Console.ReadLine());

Console.WriteLine("What is the new product name?");
var newName = Console.ReadLine();

repo.UpdateProduct(prodID, newName);

Console.WriteLine("What is the productID you want to delete?");
prodID = int.Parse(Console.ReadLine());

repo.DeleteProduct(prodID);

