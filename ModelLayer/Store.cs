using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Store
    {
        public int ID { get; set; }
        public string Franchise { get; set; }

        public District District { get; set; }
    }
}
