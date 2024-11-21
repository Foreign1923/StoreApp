using Microsoft.AspNetCore.Mvc;
using Repositories;
using Services.Contracts;

namespace StoreApp.Components
{
    public class ProductSummaryViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;
        //doğru değil
        //serviceManager olmalı


        public ProductSummaryViewComponent(IServiceManager manager) 
        {
            _manager = manager;
            
        }

        public string Invoke() => _manager.ProductService.GetAllProducts(false).Count().ToString();
    }
}
