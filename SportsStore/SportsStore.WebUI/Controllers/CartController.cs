﻿using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers {

	public class CartController : Controller {
		private IProductRepository repository;

		public CartController(IProductRepository repo) {
			repository = repo;
		}

		public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl) {
			Product product = repository.Products
				.FirstOrDefault(p => p.ProductID == productId);

			if (product != null) {
				cart.AddItem(product, 1);
			}
			return RedirectToAction("Index", new { returnUrl });
		}

		public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl) {
			Product product = repository.Products
				.FirstOrDefault(p => p.ProductID == productId);

			if (product != null) {
				cart.RemoveLine(product);
			}
			return RedirectToAction("Index", new { returnUrl });
		}

		private Cart GetCart() {

			Cart cart = (Cart)Session["Cart"];
			if (cart == null) {
				cart = new Cart();
				Session["Cart"] = cart;
			}
			return cart;
		}

		public ViewResult Index(string returnUrl) {
			return View(new CartIndexViewModel {
				Cart = GetCart(),
				ReturnUrl = returnUrl
			});
		}

        public ViewResult Index(Cart cart, string p) {
            throw new System.NotImplementedException();
        }

        public ViewResult Summary(Cart cart) {
            return View(cart);
        }
    }
}