using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsStore.Domain.Entities;

namespace UnitTests {
	/// <summary>
	/// Summary description for Calculate_Cart_TotalTest
	/// </summary>
	[TestClass]
	public class Calculate_Cart_TotalTest {

		[TestMethod]
		public void Calculate_Cart_Total() {

			// Arrange - create some test products 
			Product p1 = new Product { ProductID = 1, Name = "P1", Price = 100M };
			Product p2 = new Product { ProductID = 2, Name = "P2", Price = 50M };

			// Arrange - create a new cart 
			Cart target = new Cart();

			// Act 
			target.AddItem(p1, 1);
			target.AddItem(p2, 1);
			target.AddItem(p1, 3);
			decimal result = target.ComputeTotalValue();

			// Assert 
			Assert.AreEqual(result, 450M);
		} 
	}
}
