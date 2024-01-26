using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Pierre.Models;
using System;

namespace Pierre.Tests
{
  [TestClass]
  public class VendorTests
  {
    [TestMethod]
    public void VendorConstructor_CreateInstanceOfVendor_Vendor()
    {
      Vendor newVendor = new("Suzie's Cafe");
      Assert.AreEqual(typeof(Vendor), newVendor.GetType());
    }

    [TestMethod]
    public void GetVendorDetails_ReturnsVendorDetails_String()
    {
      string name = "Suzie's Cafe";
      Vendor suziesCafe = new(name);
      Assert.AreEqual(suziesCafe.Name, name);
    }

    [TestMethod]
    public void SetVendorDetails_SetsVendorProperties()
    {
      string name = "New and Improved Suzie's Cafe";
      Vendor suziesCafe = new("Suzie's Cafe");
      suziesCafe.Name = name;
      Assert.AreEqual(suziesCafe.Name, name);
    }

    [TestMethod]
    public void AddOrder_AddOrderToOrders_List()
    {
        Vendor suziesCafe = new("Suzie's Cafe");
        Order newOrder = new("30 croissants");
        List<Order> expected = new List<Order> {newOrder};
        suziesCafe.AddOrder(newOrder);
        CollectionAssert.AreEqual(expected, suziesCafe.Orders);
    }
  }
}