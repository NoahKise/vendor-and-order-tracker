using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Pierre.Models;
using System;

namespace Pierre.Tests
{
  [TestClass]
  public class VendorTests : IDisposable
  {
    public void Dispose()
    {
      Vendor.ClearAll();
    }

    [TestMethod]
    public void VendorConstructor_CreateInstanceOfVendor_Vendor()
    {
      Vendor newVendor = new("Suzie's Cafe", "123 fake st.");
      Assert.AreEqual(typeof(Vendor), newVendor.GetType());
    }

    [TestMethod]
    public void GetVendorDetails_ReturnsVendorDetails_String()
    {
      string name = "Suzie's Cafe";
      string location = "123 fake st.";
      Vendor suziesCafe = new(name, location);
      Assert.AreEqual(suziesCafe.Name, name);
    }

    [TestMethod]
    public void SetVendorDetails_SetsVendorProperties()
    {
      string name = "New and Improved Suzie's Cafe";
      string location = "123 fake st.";
      Vendor suziesCafe = new("Suzie's Cafe", location);
      suziesCafe.Name = name;
      Assert.AreEqual(suziesCafe.Name, name);
    }

    [TestMethod]
    public void AddOrder_AddOrderToOrders_List()
    {
        Vendor suziesCafe = new("Suzie's Cafe", "123 fake st.");
        string name = "usual";
        string dates = "every monday morning";
        Dictionary<int, string> details = new Dictionary<int, string>() { {30, "croissants"}, {10, "baguettes"} };
        int price = 130;
        bool hasPaid = true;
        Order newOrder = new(name, dates, details, price, hasPaid);
        List<Order> expected = new List<Order> {newOrder};
        suziesCafe.AddOrder(newOrder);
        CollectionAssert.AreEqual(expected, suziesCafe.Orders);
    }

    [TestMethod]
    public void FindVendor_ReturnsVendorById_Vendor()
    {
        Vendor suziesCafe = new("Suzie's Cafe", "123 fake st.");
        Vendor starbucks = new("Starbucks", "404 corporate st.");
        Vendor foundVendor = Vendor.FindVendor(2);
        Assert.AreEqual(starbucks, foundVendor);
    }

    [TestMethod]
    public void GetAllVendors_ReturnsInstances_List()
    {
        Vendor suziesCafe = new("Suzie's Cafe", "123 fake st.");
        Vendor starbucks = new("Starbucks", "404 corporate st.");
        List<Vendor> expected = new List<Vendor> {suziesCafe, starbucks};
        CollectionAssert.AreEqual(expected, Vendor.GetAll());
    }
  }
}