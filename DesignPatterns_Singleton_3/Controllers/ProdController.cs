using DesignPatterns_Singleton_3.DBManager;
using DesignPatterns_Singleton_3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace DesignPatterns_Singleton_3.Controllers
{
    public class ProdController : Controller
    {
        // GET: ProdController
        
        public ActionResult Index()
        {

            using (SqlConnection connection = DatabaseConnectionManager.Instance.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Products", connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var prod = new Product
                    {
                        Id = (int)reader["ID"],
                        ProductName = (string)reader["Name"],
                        UnitPrice = (decimal)reader["UnitPrice"]
                    };

                    Console.WriteLine("This is the product...");
                }

            }

            Parallel.For(0, 10, i =>
            {
                DatabaseConnectionManager manager = DatabaseConnectionManager.Instance;
                SqlConnection conn = manager.GetConnection();

                Console.WriteLine($"Thread {i}: Connection hash code = {conn.GetHashCode()}");

            });

            return Ok();
        }

        // GET: ProdController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProdController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProdController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProdController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProdController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProdController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
