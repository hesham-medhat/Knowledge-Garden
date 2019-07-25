using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowledge_Garden.Engine.Models
{
    public class Flower
    {
        public Employee Owner { get; set; }

        public string Title { get; set; }

        [Column("Problem", TypeName = "ntext")]
        public string Problem { get; set; }

        [Column("Solution", TypeName = "ntext")]
        public string Solution { get; set; }

        public string AttachmentNames { get; set; }

        public DateTime LastUpdateDate { get; set; }
    }
}
