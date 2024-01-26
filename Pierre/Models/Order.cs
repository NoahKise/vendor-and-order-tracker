using System.Collections.Generic;

namespace Pierre.Models
{
    public class Order
    {
        private static List<Order> _instances = new() { };
        public string Name {get; set; }
        public int Id { get; }

        public Order(string name)
        {
            Name = name;
            _instances.Add(this);
            Id = _instances.Count;
        }

        public static void ClearAll()
        {
            _instances.Clear();
        }

    }
}