using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VendorTracker.Models;

namespace VendorTracker.Controllers
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
    public ActionResult Create(string vendorName, string description)
    {
      Vendor newVendor = new Vendor(vendorName, description);
      return RedirectToAction("Index");
    }

    [HttpGet("/vendors/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> modelDictionary = new Dictionary<string, object>();
      Vendor selectedVendor = Vendor.Find(id);
      List<Order> vendorOrder = selectedVendor.Orders;
      modelDictionary.Add("vendor", selectedVendor);
      modelDictionary.Add("order", vendorOrder);
      return View(modelDictionary);
    }

    [HttpPost("vendors/{vendorId}/orders")]
    public ActionResult Create(int vendorId, string title, string description, int price, string date)
    {
      Dictionary<string, object> modelDictionary = new Dictionary<string, object>();
      Vendor foundVendor = Vendor.Find(vendorId);
      Order newOrder = new Order(title, description, price, date);
      foundVendor.AddOrder(newOrder);
      List<Order> vendorOrder = foundVendor.Orders;
      modelDictionary.Add("order", vendorOrder);
      modelDictionary.Add("vendor", foundVendor);
      return View("Show", modelDictionary);
    }

    [HttpPost("/vendors/{vendorId}/orders/delete")]
    public ActionResult DeleteAll(string searchId)
    {
      int numId = int.Parse(searchId);
      Vendor vendor = Vendor.Find(numId);
      vendor.ClearAll();
      return RedirectToAction("Index");
    }
    
    [HttpPost("/vendors/{vendorId}/delete")]
    public ActionResult DeleteVendor(string searchId)
    {
      int numId = int.Parse(searchId);
      Vendor.Delete(numId);
      return View();
    }

    [HttpPost("/vendors/{vendorId}/orders/{orderId}/delete")]
    public ActionResult DeleteOrder(int vendorId, int orderId)
    {
      Vendor vendor = Vendor.Find(vendorId);
      vendor.DeleteOneOrder(orderId);
      Order.DeleteOrder(orderId);
      return View();
    }
  }
}