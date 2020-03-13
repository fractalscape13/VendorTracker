using System.Collections.Generic;

namespace VendorTracker.Models
{
  public class Vendor
  {
    private static List<Vendor> _instances = new List<Vendor> {};
    public string Name { get; set; }
    public string Description { get; set; }
    public int Id { get; }
    public static int idCounter = 1;
    public List<Order> Orders { get; set; }

    public Vendor(string vendorName, string description)
    {
      _instances.Add(this);
      Name = vendorName;
      Description = description;
      Id = idCounter;
      Orders = new List<Order>{};
      IncreaseCounter();
    }

    public void ClearAll()
    {
      Orders.Clear();
    }

    public static void IncreaseCounter()
    {
      idCounter++;
    }

    public static List<Vendor> GetAll()
    {
      return _instances;
    }

    public static Vendor Find(int searchId)
    {
      for (int i=0; i<=_instances.Count; i++)
      {
        if (_instances[i].Id == searchId)
        {
          return _instances[i];
        }
      }
      return null;
    }

    public static void Delete(int searchId)
    {
      for (int i=0; i<=_instances.Count; i++)
      {
        if (_instances[i].Id == searchId)
        {
          _instances.RemoveAt(i);
          break;
        }
      }
    }

    public void AddOrder(Order order)
    {
      Orders.Add(order);
    }
  }
}