using Microsoft.AspNetCore.Mvc;

namespace WebApp_Lab1.Components
{
    public class CartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
