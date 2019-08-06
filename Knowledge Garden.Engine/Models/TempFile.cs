using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowledge_Garden.Engine.Models
{
    public class TempFile
    {
        [Key, Column(Order = 1)]
        public Request Request { get; set; }

        [Key, Column(Order = 1)]
        public int RequestId { get; set; }

        [Key, Column(Order = 2)]
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        public byte[] blobValue { get; set; }

        [Required]
        public string ContentType { get; set; }
    }
}
