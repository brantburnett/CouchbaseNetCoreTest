using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Couchbase;
using CouchbaseTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace CouchbaseTest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var bucket = ClusterHelper.GetBucket("travel-sample");

            var result = bucket.Query<Airline>(
                "SELECT airline.* FROM `travel-sample` airline WHERE type = 'airline' ORDER BY airline.name LIMIT 20");

            if (!result.Success)
            {
                throw new Exception("Error: " + result.Message);
            }
            else
            {
                return View(result.Rows);
            }
        }

        public async Task<IActionResult> Airline(int id)
        {
            var bucket = ClusterHelper.GetBucket("travel-sample");

            var result = await bucket.GetDocumentAsync<Airline>("airline_" + id);

            if (!result.Success)
            {
                throw new Exception("Error: " + result.Message);
            }
            else
            {
                return View(result.Document.Content);
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
