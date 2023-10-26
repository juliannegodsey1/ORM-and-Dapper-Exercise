using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;



namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);


            var productRepository = new DapperProductRepository(conn);
            var products = productRepository.GetAllProducts();
            foreach(var product in products)
            {
                Console.WriteLine(product.ProductID);
                Console.WriteLine(product.Name);
                Console.WriteLine(product.Price);
                Console.WriteLine(product.CategoryID);
                Console.WriteLine(product.OnSale);
                Console.WriteLine(product.StockLevel);
                Console.WriteLine();
                Console.WriteLine();

            }




            var repo = new DapperDepartmentRepository(conn);

            repo.InsertDepartment("John's New Department");

           var departments = repo.GetAllDepartments();

            foreach (var dept in departments)
            {
                Console.WriteLine($"{dept.DepartmentID} {dept.Name}");
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
