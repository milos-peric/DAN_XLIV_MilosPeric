using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XLIV_MilosPeric
{
    class DBService
    {
        public tblOrder AddOrder(tblOrder order)
        {
            try
            {
                using (CustomerDatabaseEntities context = new CustomerDatabaseEntities())
                {
                    tblOrder newOrder = new tblOrder();
                    newOrder.JMBG = order.JMBG;
                    newOrder.OrderStatus = order.OrderStatus;
                    newOrder.OrderDate = order.OrderDate;
                    context.tblOrders.Add(newOrder);
                    context.SaveChanges();
                    order.ID = newOrder.ID;
                    return order;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public tblPizzaOrder AddPizzaOrder(tblPizzaOrder pizzaOrder)
        {
            try
            {
                using (CustomerDatabaseEntities context = new CustomerDatabaseEntities())
                {

                    tblPizzaOrder newPizzaOrder = new tblPizzaOrder();
                    newPizzaOrder.Amount = pizzaOrder.Amount;
                    newPizzaOrder.OrderID = pizzaOrder.OrderID;
                    newPizzaOrder.PizzaID = pizzaOrder.PizzaID;

                    context.tblPizzaOrders.Add(newPizzaOrder);
                    context.SaveChanges();
                    pizzaOrder.ID = newPizzaOrder.ID;


                    return pizzaOrder;

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public void ApproveOrder(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(int id)
        {
            try
            {
                using (CustomerDatabaseEntities context = new CustomerDatabaseEntities())
                {
                    tblOrder orderToDelete = (from r in context.tblOrders where r.ID == id select r).First();
                    context.tblOrders.Remove(orderToDelete);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }

        public void EditOrder(tblOrder order)
        {
            try
            {
                using (CustomerDatabaseEntities context = new CustomerDatabaseEntities())
                {
                    tblOrder orderDB = (from x in context.tblOrders where x.ID == order.ID select x).First();

                    orderDB.OrderStatus = order.OrderStatus;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());

            }
        }

        public tblOrder GetOrderByID(int id)
        {
            try
            {
                using (CustomerDatabaseEntities context = new CustomerDatabaseEntities())
                {


                    tblOrder order = (from x in context.tblOrders where x.ID == id select x).First();

                    return order;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public List<tblOrder> GetOrders()
        {
            try
            {
                using (CustomerDatabaseEntities context = new CustomerDatabaseEntities())
                {
                    List<tblOrder> list = new List<tblOrder>();
                    list = (from x in context.tblOrders select x).ToList();

                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public List<tblOrder> GetOrdersOfGuest(string JMBG)
        {
            try
            {
                using (CustomerDatabaseEntities context = new CustomerDatabaseEntities())
                {
                    List<tblOrder> list = new List<tblOrder>();
                    list = (from x in context.tblOrders where x.JMBG == JMBG select x).ToList();

                    list.Sort((x, y) => DateTime.Compare((DateTime)x.OrderDate, (DateTime)y.OrderDate));

                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public List<tblPizzaOrder> GetPizzaOrdersByOrderID(int orderID)
        {
            try
            {
                using (CustomerDatabaseEntities context = new CustomerDatabaseEntities())
                {
                    List<tblPizzaOrder> list = new List<tblPizzaOrder>();
                    list = (from x in context.tblPizzaOrders where x.OrderID == orderID select x).ToList();
                    foreach (var item in list)
                    {
                        tblPizzaMenu pizza = (from x in context.tblPizzaMenus where x.ID == item.PizzaID select x).First();
                        tblOrder order = (from x in context.tblOrders where x.ID == item.OrderID select x).First();
                        item.tblPizzaMenu = pizza;
                        item.tblOrder = order;

                    }

                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public List<tblPizzaMenu> GetPizzaMenu()
        {
            try
            {
                using (CustomerDatabaseEntities context = new CustomerDatabaseEntities())
                {
                    List<tblPizzaMenu> list = new List<tblPizzaMenu>();
                    list = (from x in context.tblPizzaMenus select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }


        public tblSelectedPizza AddToSelectedMenu(tblPizzaMenu pizza)
        {
            try
            {
                using (CustomerDatabaseEntities context = new CustomerDatabaseEntities())
                {
                    tblSelectedPizza newSelectedPizza = new tblSelectedPizza();
                    newSelectedPizza.PizzaName = pizza.PizzaName;
                    newSelectedPizza.PizzaType = pizza.PIzzaType;
                    newSelectedPizza.Price = pizza.Price;
                    context.tblSelectedPizzas.Add(newSelectedPizza);
                    context.SaveChanges();
                    pizza.ID = newSelectedPizza.ID;
                    return newSelectedPizza;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public List<tblSelectedPizza> GetSelected()
        {
            try
            {
                using (CustomerDatabaseEntities context = new CustomerDatabaseEntities())
                {
                    List<tblSelectedPizza> list = new List<tblSelectedPizza>();
                    list = (from x in context.tblSelectedPizzas select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }


        public void RemoveSelectedPizza(int id)
        {
            try
            {
                using (CustomerDatabaseEntities context = new CustomerDatabaseEntities())
                {
                    tblSelectedPizza pizzaToRemove = (from p in context.tblSelectedPizzas where p.ID == id select p).First();
                    context.tblSelectedPizzas.Remove(pizzaToRemove);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }

        public tblPizzaMenu GetPizzaByID(int id)
        {
            try
            {
                using (CustomerDatabaseEntities context = new CustomerDatabaseEntities())
                {
                    tblPizzaMenu pizza = (from x in context.tblPizzaMenus where x.ID == id select x).First();
                    return pizza;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
    }
}
