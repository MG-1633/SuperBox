using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperBox_manager
{
    internal class superboxx
    {
        
            public int Id { get; set; }
            public string Location { get; set; }
            public List<Order> OutgoingOrders { get; set; }
            public List<Order> IncomingOrders { get; set; }

            public SuperBox(int id, string location)
            {
                Id = id;
                Location = location;
                OutgoingOrders = new List<Order>();
                IncomingOrders = new List<Order>();
            }
        

    }
}
