using Microsoft.AspNetCore.Mvc;
using OnLineShop.DB;
using OnLineShop.DB.Models;
using ProductModel.Helpers;
using ProductModel.Models;
using System;

namespace ProductModel.Controllers
{
    public class CartController : Controller
    {
        public readonly IGetProducts ProductRepository;
        public readonly IGetCarts CartRepository; 
        public readonly IGetOrders OrderRepository;
        public CartController(IGetProducts products, IGetCarts carts, IGetOrders orderRepository)
        {
            this.ProductRepository = products;
            this.CartRepository = carts;
            OrderRepository = orderRepository;
        }

        public IActionResult Index()
        {
            CartDB cart = CartRepository.TryGetByUserId("md");
            return View(Mapping.CardDBToCart(cart));
        }

        public IActionResult Add(int idProduct)
        {
            ProductDB item = ProductRepository.TryGetById(idProduct);
            CartRepository.Add(item,"md");
            return RedirectToAction("Index");
        }




        public IActionResult DecreaseProduct(int idProduct)
        {
            //Cart cart = carts.GetCart(Constants.MD);
            //cart.DecreaseProduct(idProduct);
            //return RedirectToAction("Index");
            return View();
        }

        public IActionResult Delete()
        {
            //Cart cart = carts.GetCart(Constants.MD);
            //cart.Clear();
            //return RedirectToAction("Index");
            return View();
        }



        public IActionResult AddOrder(string user)
        {
            var cart = CartRepository.TryGetByUserId(user);
            OrderRepository.AddOrder(new OrderDB() { User = user, Cart = cart,Id = Guid.NewGuid() });
            return RedirectToAction("Index");
        }
    }
}
