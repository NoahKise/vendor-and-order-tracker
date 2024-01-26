using Microsoft.AspNetCore.Mvc;
using Pierre.Models;
using System.Collections.Generic;

namespace Pierre.Controllers
{
    public class OrdersController : Controller
    {
        [HttpGet("/vendors/{vendorId}/orders/new")]
        public ActionResult New(int vendorId)
        {
            Vendor vendor = Vendor.FindVendor(vendorId);
            return View(vendor);
        }
    }
}