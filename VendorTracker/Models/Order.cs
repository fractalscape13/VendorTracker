using System.Collections.Generic;

namespace VendorTracker.Models
{
  public class Order
  {
    private static List<Order> _instances = new List<Order> { };
    public string Title { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public string Date { get; set; }
    public int Id { get; }
    public static int idCounter = 1;

    public Order(string title, string description, int price, string date)
    {
      _instances.Add(this);
      Title = title;
      Description = description;
      Price = price;
      Date = date;
      Id = idCounter;
      IncreaseCounter();
    }

    public static void IncreaseCounter()
    {
      idCounter++;
    }

    public static List<Order> GetAll()
    {
      return _instances;
    }

    public static Order Find(int searchId)
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

    public static void DeleteOrder(int searchId)
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
  }
}