using Entitites.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using StoreApp.Models;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;

        //ıoC register resolve dispose
        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }
        //public IEnumerable<Product> Index()
        //{

        //    //var context = new RepositoryContext(
        //    //    new DbContextOptionsBuilder<RepositoryContext>().UseSqlite("Data Source = C:\\Users\\orkun\\source\\repos\\ProductDb.db").Options
        //    //    //C:\\Users\\orkun\\source\\repos\\ProductDb.db"
        //    //    );

        //    return _context.Products;
        //}
        public IActionResult Index(ProductRequestParameters p)
        {
            var products = _manager.ProductService.GetAllProductsWithDetails(p);
            var pagination = new Pagination()
            {
                CurrentPage = p.PageNumber,
                ItemsPerPage = p.PageSize,
                TotalItems = _manager.ProductService.GetAllProducts(false).Count()
            };

            //false kısmı izlemesine gerek yok demek oluyor sanırım benim 
            //saveAllChanges ı veya Save() methodunu çağırmam gerekiyor
            return View(new ProductListViewModel()
            {
                Products = products,
                Pagination = pagination

            });
        }
        public IActionResult Get([FromRoute(Name ="id")]int id)
        {

            /// Product product = _manager.Products.First(p => p.ProductId.Equals(id));
            // return View(product);
            var model = _manager.ProductService.GetOneProduct(id, false);
            ViewData["Title"] = model?.ProductName;
            return View(model);
        }

    }
}
