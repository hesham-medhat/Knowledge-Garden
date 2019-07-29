using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowledge_Garden.Engine.Models
{
    public class Notification
    {
        public virtual Employee Employee { get; set; }

        public virtual Flower Flower { get; set; }


        [Key]
        [Column(Order = 1)]
        public string EmployeeUsername { get; set; }

        [Key]
        [Column(Order = 2)]
        public int FlowerId { get; set; }
    }
}
