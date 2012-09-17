﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using SportsStore.WebUI.Models;
using Moq;

namespace UnitTests {
	/// <summary>
	/// Summary description for Can_Add_New_Lines_Test
	/// </summary>
	[TestClass]
	public class Can_Add_New_Lines_Test {
		
		[TestMethod] 
		public void Can_Add_New_Lines() { 
 
			// Arrange - create some test products
			Product p1 = new Product { ProductID = 1, Name = "P1" }; 
			Product p2 = new Product { ProductID = 2, Name = "P2" }; 
 
			// Arrange - create a new cart 
			Cart target = new Cart(); 
 
			// Act 
			target.AddItem(p1, 1); 
			target.AddItem(p2, 1); 
			CartLine[] results = target.Lines.ToArray(); 
 
			// Assert 
			Assert.AreEqual(results.Length, 2); 
			Assert.AreEqual(results[0].Product, p1); 
			Assert.AreEqual(results[1].Product, p2); 
		} 
	}
}
