using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperBox_manager
{
    internal class OrderManager
    {
        
            private List<Order> orders;
            private int nextOrderId;

            public OrderManager()
            {
                orders = new List<Order>();
                nextOrderId = 1;
            }

            public void PlaceOrder(User sender, User receiver, SuperBox source, SuperBox destination, bool isUrgent)
            {
                var order = new Order(nextOrderId++, sender, receiver, source, destination, isUrgent);
                orders.Add(order);
                source.OutgoingOrders.Add(order);
                destination.IncomingOrders.Add(order);
            }

            public List<Order> GetOrdersBySender(User sender)
            {
                return orders.Where(o => o.Sender == sender).ToList();
            }

            public List<Order> GetOrdersByReceiver(User receiver)
            {
                return orders.Where(o => o.Receiver == receiver).ToList();
            }

            public void CancelOrder(int orderId, User requester)
            {
                var order = orders.FirstOrDefault(o => o.OrderId == orderId);
                if (order == null)
                    throw new Exception("Comanda nu a fost găsită.");
                if (order.Sender != requester)
                    throw new Exception("Doar expeditorul poate anula comanda.");
                if (order.Status != OrderStatus.Placed)
                    throw new Exception("Comanda nu poate fi anulată.");

                order.Status = OrderStatus.Cancelled;
                order.SourceSuperBox.OutgoingOrders.Remove(order);
                order.DestinationSuperBox.IncomingOrders.Remove(order);
            }
        

    }
}
