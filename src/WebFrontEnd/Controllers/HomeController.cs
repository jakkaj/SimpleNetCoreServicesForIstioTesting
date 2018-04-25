using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebFrontEnd.Models;

namespace WebFrontEnd.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var web = new WebClient();
            var result = await web.DownloadStringTaskAsync("http://services/api/todo");
            ViewData["result"] = result;
            return View();
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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
