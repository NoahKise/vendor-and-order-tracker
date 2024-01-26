using System.Collections.Generic;

namespace Pierre.Models
{
    public class Vendor
    {
        private static List<Vendor> _instances = new() { };
        public string Name { get; set; }
        public int Id { get; }
        public List<Order> Orders { get; set; }

        public Vendor(string name)
        {
            Name = name;
            _instances.Add(this);
            Id = _instances.Count;
            Orders = new List<Order> { };
        }

        public void AddOrder(Order order)
        {
            Orders.Add(order);
        }

        public static Vendor FindVendor(int id)
        {
            return _instances[id - 1];
        }

        public static void ClearAll()
        {
            _instances.Clear();
        }

        public static List<Vendor> GetAll()
        {
            return _instances;
        }
    }
}