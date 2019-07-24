using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowledge_Garden.Engine.Models
{
    public class Flower
    {
        public Employee Owner { get; set; }

        public string Title { get; set; }

        public string Problem { get; set; }

        public string Solution { get; set; }

        public string AttachmentNames { get; set; }
    }
}
