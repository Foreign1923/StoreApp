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
        
        //buraya bi log projesi gibi bir �ey yap�labilir
        //kullan�c�n�n sitede ge�irdi�i zaman aral��� 
        //veya shopping cartta ge�irdi�i zaman aral��� 
        //ayn� �ekilde dashboardda ge�irdi�i zaman aral���

        public IActionResult Index()
        {
            ViewData["Title"] = "Welcome";
            return View();
        }

    }
}
