using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowledge_Garden.DataEntities
{
    public class TempFile
    {
        public Request Request { get; set; }

        public int RequestId { get; set; }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        public byte[] blobValue { get; set; }

        [Required]
        public string ContentType { get; set; }
    }
}
