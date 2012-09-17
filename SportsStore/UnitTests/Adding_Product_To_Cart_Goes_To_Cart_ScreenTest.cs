using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using SportsStore.WebUI.Binders;
using System.Web.Mvc;

namespace UnitTests
{
    /// <summary>
    /// Summary description for Adding_Product_To_Cart_Goes_To_Cart_ScreenTest
    /// </summary>
    [TestClass]
    public class Adding_Product_To_Cart_Goes_To_Cart_ScreenTest
    {
        
        [TestMethod]
        public void Adding_Product_To_Cart_Goes_To_Cart_Screen() {
            
            // Arrange - create the mock repository
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductID = 1, Name = "P1", Category = "Apples"},
            }.AsQueryable());
            
            // Arrange - create a Cart
            Cart cart = new Cart();

            // Arrange - create the controller
            CartController target = new CartController(mock.Object);
            
            // Act - add a product to the cart
            RedirectToRouteResult result = target.AddToCart(cart, 2, "myUrl");
            
            // Assert
            Assert.AreEqual(result.RouteValues["action"], "Index");
            Assert.AreEqual(result.RouteValues["returnUrl"], "myUrl");
        }
    }
}
