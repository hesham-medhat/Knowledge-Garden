using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowledge_Garden.Engine.Models
{
    public class Attachment
    {
        /// <summary>
        /// The flower that this attachment belongs to
        /// </summary>
        [Key]
        [Column(Order=1)]
        [Required]
        public Flower Flower { get; set; }

        [Key]
        [Column(Order = 2)]
        [Required]
        public string Name { get; set; }

        [Required]
        public IEnumerable<byte> blobValue { get; set; }
    }
}
