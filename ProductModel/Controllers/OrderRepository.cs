using Microsoft.AspNetCore.Mvc;
using OnLineShop.DB;
using ProductModel.Helpers;
using System;

namespace ProductModel.Controllers
{
    public class OrderController : Controller
    {
        private readonly IGetOrders _dbOrders;
        public OrderController(IGetOrders dbOrders)
        {
            _dbOrders = dbOrders;
        }

        public IActionResult Index(Guid id)
        {
            var order = _dbOrders.TryGetOrderById(id);
            return View(Mapping.ToOrderViewModel(order));
        }
    }
}
