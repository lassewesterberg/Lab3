using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Entities;
using SportsStore.Domain.Abstract;
using SportsStore.WebUI.Controllers;

namespace UnitTests
{
    /// <summary>
    /// Summary description for Can_Add_To_CartTest
    /// </summary>
    [TestClass]
    public class Can_Add_To_CartTest
    {

        [TestMethod]
        public void Can_Add_To_Cart()
        {
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
            target.AddToCart(cart, 1, null);
            
            // Assert
            Assert.AreEqual(cart.Lines.Count(), 1);
            Assert.AreEqual(cart.Lines.ToArray()[0].Product.ProductID, 1);
        }
    }
}
