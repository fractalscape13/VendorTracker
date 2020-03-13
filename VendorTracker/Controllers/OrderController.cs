using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VendorTracker.Models;

namespace VendorTracker.Controllers
{
  public class OrderController : Controller
  {
    [HttpGet("/vendor/{vendorId}/order/{orderId}")]
    public ActionResult Show(int vendorId, int orderId)
    {
      Order currentOrder = Order.Find(orderId);
      Vendor currentVendor = Vendor.Find(vendorId);
      Dictionary<string, object> modelDictionary = new Dictionary<string, object>();
      modelDictionary.Add("order", currentOrder);
      modelDictionary.Add("vendor", currentVendor);
      return View(modelDictionary);
    }

    [HttpGet("/vendor/{vendorId}/order/new")]
    public ActionResult New(int vendorId)
    {
      Vendor vendor = Vendor.Find(vendorId);
      return View(vendor);
    }

    [HttpPost("/vendor/{vendorId}/order/{orderId}/delete")]
    public ActionResult DeleteOrder(int orderId)
    {
      Order.DeleteOrder(orderId);
      return RedirectToAction("Show");
    }

    [HttpPost("/vendor/{vendorId}/order/delete")]
    public ActionResult DeleteAll(int vendorId)
    {
      Vendor vendor = Vendor.Find(vendorId);
      vendor.ClearAll();
      return RedirectToAction("Show");
    }
  }
}