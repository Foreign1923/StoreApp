using Microsoft.AspNetCore.Mvc;
using StoreApp.Models;
using System.Diagnostics;

namespace StoreApp.Controllers
{
    public class HomeController : Controller
    {
       // private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        
        //buraya bi log projesi gibi bir þey yapýlabilir
        //kullanýcýnýn sitede geçirdiði zaman aralýðý 
        //veya shopping cartta geçirdiði zaman aralýðý 
        //ayný þekilde dashboardda geçirdiði zaman aralýðý

        public IActionResult Index()
        {
            ViewData["Title"] = "Welcome";
            return View();
        }

    }
}
