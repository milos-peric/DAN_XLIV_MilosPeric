using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XLIV_MilosPeric
{
    class PizzaItems
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Price { get; set; }
        public string OrderStatus { get; set; }
        public string CustomerID { get; set; }
        public DateTime OrderDate { get; set; }

        public PizzaItems()
        {

        }

        public PizzaItems(int id, string name, string type, string price, string orderStatus, string customerId, DateTime orderDate)
        {
            ID = id;
            Name = name;
            Type = type;
            Price = price;
            OrderStatus = orderStatus;
            CustomerID = customerId;
            OrderDate = orderDate;
        }

        public static ObservableCollection<PizzaItems> Load()
        {
            ObservableCollection<PizzaItems> ocPizzas = new ObservableCollection<PizzaItems>() {
            new PizzaItems(1, "Margaritha", "Small", "$10.5", "Waiting", "1103987180000", DateTime.Now),
            new PizzaItems(2, "Margaritha", "Medium", "$13.5", "Waiting", "1103987180000", DateTime.Now),
            new PizzaItems(3, "Margaritha", "Large", "$16.5", "Waiting", "1103987180000", DateTime.Now),
            new PizzaItems(2, "Capricciosa", "Small", "$11.8", "Waiting", "1103987180000", DateTime.Now),
            new PizzaItems(2, "Capricciosa", "Medium", "$14.8", "Waiting", "1103987180000", DateTime.Now),
            new PizzaItems(2, "Capricciosa", "Large", "$17.8", "Waiting", "1103987180000", DateTime.Now),
            new PizzaItems(3, "Four Seasons", "Small","$12.2", "Waiting", "1103987180000", DateTime.Now),
            new PizzaItems(3, "Four Seasons", "Medium","$14.2", "Waiting", "1103987180000", DateTime.Now),
            new PizzaItems(3, "Four Seasons", "Large","$16.2", "Waiting", "1103987180000", DateTime.Now),
            new PizzaItems(4, "Calzone", "Small", "$11.4", "Waiting", "1103987180000", DateTime.Now),
            new PizzaItems(4, "Calzone", "Medium", "$13.4", "Waiting", "1103987180000", DateTime.Now),
            new PizzaItems(4, "Calzone", "Large", "$16.4", "Waiting", "1103987180000", DateTime.Now)
        };
            return ocPizzas;
        }
    }
}
