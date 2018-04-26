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
            return RedirectToAction("Index", "Todo");
        }

    }
}
