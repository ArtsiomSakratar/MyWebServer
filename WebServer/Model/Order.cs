using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer.Model
{
    public class Order : Entity
    {
        public string OrderID;

        public string CreateDate;

        public string ShipDate;

        public double Price;
    }
}
