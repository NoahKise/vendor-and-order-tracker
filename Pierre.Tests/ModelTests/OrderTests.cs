using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pierre.Models;

namespace Pierre.Tests
{
  [TestClass]
  public class OrderTests : IDisposable
  {
    public void Dispose()
    {
      Order.ClearAll();
    }

    [TestMethod]
    public void OrderConstructor_CreatesInstanceOfOrder_Order()
    {
      string name = "usual";
      string dates = "every monday morning";
      Dictionary<int, string> details = new Dictionary<int, string>() { { 30, "croissants" }, { 10, "baguettes" } };
      int price = 130;
      bool hasPaid = true;
      Order newOrder = new(name, dates, details, price, hasPaid);
      Assert.AreEqual(typeof(Order), newOrder.GetType());
    }

    [TestMethod]
    public void GetOrderDetails_ReturnsOrderDetails_String()
    {
      string name = "usual";
      string dates = "every monday morning";
      Dictionary<int, string> details = new Dictionary<int, string>() { { 30, "croissants" }, { 10, "baguettes" } };
      int price = 130;
      bool hasPaid = true;
      Order newOrder = new(name, dates, details, price, hasPaid);
      Assert.AreEqual(newOrder.Name, name);
    }

    [TestMethod]
    public void SetOrderDetails_SetsOrderProperties()
    {
      string name = "unique order";
      string dates = "every monday morning";
      Dictionary<int, string> details = new Dictionary<int, string>() { { 30, "croissants" }, { 10, "baguettes" } };
      int price = 130;
      bool hasPaid = true;
      Order newOrder = new("usual", dates, details, price, hasPaid);
      newOrder.Name = name;
      Assert.AreEqual(newOrder.Name, name);
    }

    [TestMethod]
    public void FindOrder_ReturnsOrderById_Order()
    {
      string name = "usual";
      string dates = "every monday morning";
      Dictionary<int, string> details = new Dictionary<int, string>() { { 30, "croissants" }, { 10, "baguettes" } };
      int price = 130;
      bool hasPaid = true;
      Order suziesOrder = new(name, dates, details, price, hasPaid);
      string name2 = "unique order";
      string dates2 = "may 3rd";
      Dictionary<int, string> details2 = new Dictionary<int, string>() { { 100, "croissants" }, { 5, "baguettes" } };
      int price2 = 320;
      bool hasPaid2 = false;
      Order starbucksOrder = new(name2, dates2, details2, price2, hasPaid2);
      Order foundOrder = Order.FindOrder(2);
      Assert.AreEqual(starbucksOrder, foundOrder);
    }

    [TestMethod]
    public void GetAllOrders_ReturnsInstances_List()
    {
      string name = "usual";
      string dates = "every monday morning";
      Dictionary<int, string> details = new Dictionary<int, string>() { { 30, "croissants" }, { 10, "baguettes" } };
      int price = 130;
      bool hasPaid = true;
      Order suziesOrder = new(name, dates, details, price, hasPaid);
      string name2 = "unique order";
      string dates2 = "may 3rd";
      Dictionary<int, string> details2 = new Dictionary<int, string>() { { 100, "croissants" }, { 5, "baguettes" } };
      int price2 = 320;
      bool hasPaid2 = false;
      Order starbucksOrder = new(name2, dates2, details2, price2, hasPaid2);
      List<Order> expected = new List<Order> { suziesOrder, starbucksOrder };
      CollectionAssert.AreEqual(expected, Order.GetAll());
    }
  }
}