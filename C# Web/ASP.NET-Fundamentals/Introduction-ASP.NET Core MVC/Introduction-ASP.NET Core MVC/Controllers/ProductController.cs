using Introduction_ASP.NET_Core_MVC.Models.Product;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Introduction_ASP.NET_Core_MVC.Controllers
{
    public class ProductController : Controller
    {

        private IEnumerable<ProductViewModel> _products = new List<ProductViewModel>() {
        new ProductViewModel(1,"cheese", 1.4m),
        new ProductViewModel(2,"bacon", 5.5m),
        new ProductViewModel(3,"Praz", 3.4m),
        };
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult All()
        {   
            return View(_products);
        }


        [HttpPost]
        public IActionResult ById(int id)
        {
            var product = _products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return BadRequest();
            }
            return View(product);
        }
    }
}
