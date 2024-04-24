using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverTime.Class
{
    public class Info
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return "ID: " + Id + ", Name: " + Name;
        }
    }
}
