using Entitites.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;
using StoreApp.Infrastructure.Extensions;

namespace StoreApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IServiceManager _manager;

        public CartModel(IServiceManager manager, Cart cartService)
        {

            _manager = manager;
            Cart = cartService;


        }
        public Cart Cart { get; set; } //IoC kayd� olu�turuyoruz
        //newlemem laz�m ��nk� reference kay�tl� 

        public string ReturnUrl { get; set; } = "/";


        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //e�er herhangi bir reference yoksa anasayfaya y�nlendiriyoruz
           // Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }
        public IActionResult OnPost(int productId, string returnUrl)
        {
            Product? product = _manager.
                ProductService.
                GetOneProduct(productId, false);
            //burada database e eri�im i�in getirdik


            if (product is not null)
            {
               // Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

                Cart.AddItem(product, 1);
                //HttpContext.Session.SetJson<Cart>("cart", Cart);

            }
            return RedirectToPage(new {returnUrl = returnUrl}); // returnUrl e gelen url in d�nmesi laz�m
        }
        public IActionResult OnPostRemove(int id, string returnUrl)
        {
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            Cart.RemoveLine(Cart.Lines.First(cl => cl.Product.ProductId.Equals(id)).Product);
           // HttpContext.Session.SetJson<Cart>("cart", Cart);

            return Page();

        }
    }
}
