using Microsoft.AspNetCore.Mvc;
using Pierre.Models;
using System.Collections.Generic;

namespace Pierre.Controllers
{
  public class VendorsController : Controller
  {
    [HttpGet("/vendors")]
    public ActionResult Index()
    {
      List<Vendor> allVendors = Vendor.GetAll();
      return View(allVendors);
    }

    [HttpGet("/vendors/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/vendors")]
    public ActionResult Create(string vendorName, string vendorLocation)
    {
      Vendor newVendor = new(vendorName, vendorLocation);
      return RedirectToAction("Index");
    }

    [HttpGet("/vendors/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor selectedVendor = Vendor.FindVendor(id);
      List<Order> vendorOrders = selectedVendor.Orders;
      model.Add("vendor", selectedVendor);
      model.Add("orders", vendorOrders);
      return View(model);
    }

    [HttpPost("/vendors/{vendorId}/orders")]
    public ActionResult Create(int vendorId, string orderName, string orderDates, string[] detailQuantities, string[] detailItems, int orderPrice, bool orderHasPaid)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Vendor foundVendor = Vendor.FindVendor(vendorId);
      Dictionary<int, string> orderDetails = new Dictionary<int, string>();
      for (int i = 0; i < detailQuantities.Length; i++)
      {
        if (int.TryParse(detailQuantities[i], out int quantity))
        {
          orderDetails.Add(quantity, detailItems[i]);
        }
      }
      Order newOrder = new Order(orderName, orderDates, orderDetails, orderPrice, orderHasPaid);
      foundVendor.AddOrder(newOrder);
      List<Order> vendorOrders = foundVendor.Orders;
      model.Add("orders", vendorOrders);
      model.Add("vendor", foundVendor);
      return View("Show", model);
    }
  }
}