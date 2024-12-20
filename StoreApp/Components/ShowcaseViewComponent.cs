﻿using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System.Runtime.InteropServices;

namespace StoreApp.Components
{
    public class ShowcaseViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public ShowcaseViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }
        public IViewComponentResult Invoke(string page = "default")
        {
            var product = _manager.ProductService.GetShowCaseProducts(false);
            return page.Equals("default") ?
                View(product):
                View("List", product);
        }


    }
}
