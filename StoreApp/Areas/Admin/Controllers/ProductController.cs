using Entitites.Dtos;
using Entitites.Models;
using Entitites.RequestParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;
using StoreApp.Models;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;

        }

        public IActionResult Index([FromQuery] ProductRequestParameters p)
        {
            ViewData["Title"] = "Products";   
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
        public IActionResult Create()
        {
            TempData["info"] = "Please fill the form.";
            ViewBag.Categories = GetCategoriesSelectList();
            //    new SelectList(_manager.CategoryService.GetAllCategories(false),
            //    "CategoryId",
            //    "CategoryName", "1");
            return View();
        }

        private SelectList GetCategoriesSelectList()
        {
            return new SelectList(_manager.CategoryService.GetAllCategories(false),
                "CategoryId",
                "CategoryName", "1");

        }
        //kısa bir not post isteğini karakter sınırı koymak lazım 
        //internet varken belirli bir karakter sınırına veya istek sınırı
        //var evet ama offline olup istek sınırını overload edebiliyor
        //olması lazım bunun için bir önlem alınmalı

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] ProductDtoForInsertion productDto, IFormFile file)
        {
            //formdan gelen file ı alabilmek için bir interface inşa ettik IFormfile
            //file operation
            //sunucuda gelen imageları şu c dosyasına koyacaksın gibi bir yaklaşım


            if (ModelState.IsValid)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot", "images", file.FileName);
                //bunu sanırım sitede gösteremediğim için kaldırdım ama 
                //testini yapıp tekrardan eklmemem gerekiyor
                //şimdilik yorum satırından alıyorum

                using (var strem = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(strem);
                    //asenkron olarak dosya yüklemesi yapıyoruz 
                    //maliyetli olduğu için using methodunu böyle kullandık
                }
                //productDto.ImageUrl = $"/images/{file.FileName}";
                productDto.ImageUrl = String.Concat("~/images/", file.FileName);
                //burada dosya adının başına /images/ ekledik
                //concat ifadesi ile string birleştirdik aslında
                _manager.ProductService.CreateProduct(productDto);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            ViewBag.Categories = GetCategoriesSelectList();
            var model = _manager.ProductService.GetOneProductForUpdate(id, false);
            ViewData["Title"] = model?.ProductName;
            //sekme ismini modelde bir product varsa sekmenin ismine koy
            //mesela monsternotbook abrav7
            return View(model);
            //buradan gelen product asp-for ile eşleştirip getoneproduct 
            //methodu sayesinde gelen product ı eşleştirdi
            //Fromroute dememiz bu yüzden oluyor
            //eğer gelen link ?id=1 şeklinde olsaydı QueryString şeklinde ifade edecektik
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] ProductDtoForUpdate productDto, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(),
               "wwwroot", "images", file.FileName);

                using (var strem = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(strem);
                    //asenkron olarak dosya yüklemesi yapıyoruz 
                    //maliyetli olduğu için using methodunu böyle kullandık
                }
                productDto.ImageUrl = $"/images/{file.FileName}";
                _manager.ProductService.UpdateOneProduct(productDto);
                TempData["success"] = $"Product has been created";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            //pop up koymayı denesene
            _manager.ProductService.DeleteOneProduct(id);
            TempData["danger"] = "The product has been removed.";
            return RedirectToAction("Index");
            //return View();
        }
    }
}
