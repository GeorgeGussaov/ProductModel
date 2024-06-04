using Microsoft.AspNetCore.Mvc;
using ProductModel.Models;
using OnLineShop.DB.Models;
using OnLineShop.DB;
using ProductModel.Helpers;

namespace ProductModel.Controllers
{
    public class AdminController : Controller
    {
        public readonly IGetProducts RepositoryProductDBs;
        public readonly IGetOrders _dbOrders;

        public AdminController(IGetProducts list_ProductDBs, IGetOrders dbOrders)
        {
            this.RepositoryProductDBs = list_ProductDBs;
            this._dbOrders = dbOrders;
        }

        public IActionResult Orders()
        {
            var orders = _dbOrders.GetOrderDBs();
            return View(Mapping.ToOrdersViewModel(orders));
        }

        public IActionResult Users()
        {
            return View();
        }

        public IActionResult Roles()
        {
            return View();
        }

        public IActionResult Products()
        {

            return View(Mapping.ListProductDBToListProduct(RepositoryProductDBs.GetProducts()));
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            // если не прошел валидацию возвращаем на ту же вьюшку для редактирования
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            // тут сохранить продукт в product DB
            RepositoryProductDBs.Add(Mapping.ProductToProductDB(product));
            return RedirectToAction("Index", "Product");
        }
    }

}
