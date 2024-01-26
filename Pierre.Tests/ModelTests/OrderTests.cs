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
      Order newOrder = new(name, dates, details);
      Assert.AreEqual(typeof(Order), newOrder.GetType());
    }
  }
}