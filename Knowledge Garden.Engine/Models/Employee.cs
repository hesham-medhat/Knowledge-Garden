using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowledge_Garden.Engine.Models
{
    public class Employee
    {
        public string Username { get; set; }

        public IEnumerable<Flower> OwnedFlowers { get; set; }

        public IEnumerable<Flower> UnreadFlowers { get; set; }
    }
}
