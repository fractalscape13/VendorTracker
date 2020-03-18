using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VendorTracker.Models;

namespace VendorTracker.Controllers
{
  public class OrdersController : Controller
  {
    [HttpGet("/vendors/{vendorId}/orders/{orderId}")]
    public ActionResult Show(int vendorId, int orderId)
    {
      Order currentOrder = Order.Find(orderId);
      Vendor currentVendor = Vendor.Find(vendorId);
      Dictionary<string, object> modelDictionary = new Dictionary<string, object>();
      modelDictionary.Add("order", currentOrder);
      modelDictionary.Add("vendor", currentVendor);
      return View(modelDictionary);
    }

    [HttpGet("/vendors/{vendorId}/orders/new")]
    public ActionResult New(int vendorId)
    {
      Vendor vendor = Vendor.Find(vendorId);
      return View(vendor);
    }
  }
}