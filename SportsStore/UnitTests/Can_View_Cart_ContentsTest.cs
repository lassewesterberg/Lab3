using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using SportsStore.WebUI.Models;

namespace UnitTests
{
    /// <summary>
    /// Summary description for Can_View_Cart_ContentsTest
    /// </summary>
    [TestClass]
    public class Can_View_Cart_ContentsTest
    {

        [TestMethod]
        public void Can_View_Cart_Contents()
        {
            // Arrange - create a Cart
            Cart cart = new Cart();
            
            // Arrange - create the controller
            CartController target = new CartController(null);
            
            // Act - call the Index action method
            CartIndexViewModel result
                = (CartIndexViewModel)target.Index(cart, "myUrl").Viewbag.Model;
            
            // Assert
            Assert.AreSame(result.Cart, cart);
            Assert.AreEqual(result.ReturnUrl, "myUrl");
        }
    }
}
