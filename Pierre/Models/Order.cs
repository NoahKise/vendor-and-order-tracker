using System.Collections.Generic;

namespace Pierre.Models
{
    public class Order
    {
        private static List<Order> _instances = new() { };
        public string Name { get; set; }
        public int Id { get; }
        public string Dates { get; set; }
        public Dictionary<int, string> Details { get; set; }
        public int Price { get; set; }
        public bool HasPaid { get; set; }

        public Order(string name, string dates, Dictionary<int, string> details, int price, bool hasPaid)
        {
            Name = name;
            Dates = dates;
            Details = details;
            Price = price;
            HasPaid = hasPaid;
            _instances.Add(this);
            Id = _instances.Count;
        }

        public static Order FindOrder(int id)
        {
            return _instances[id - 1];
        }

        public static List<Order> GetAll()
        {
            return _instances;
        }

        public static void ClearAll()
        {
            _instances.Clear();
        }

    }
}