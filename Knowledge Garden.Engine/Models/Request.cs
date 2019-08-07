using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowledge_Garden.Engine.Models
{
    public class Request
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        public Employee Owner { get; set; }

        [Required]
        public string OwnerUsername { get; set; }


        public virtual ICollection<TempFile> TempFiles { get; set; }
    }
}
