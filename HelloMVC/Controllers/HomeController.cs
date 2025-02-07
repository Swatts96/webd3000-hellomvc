using System.Diagnostics;
using HelloMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloMVC.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
