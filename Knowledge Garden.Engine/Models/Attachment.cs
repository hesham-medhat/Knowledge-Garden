using System;
using System.Collections.Generic;
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
        public Flower flower { get; set; }
        public IEnumerable<byte> blobValue { get; set; }
    }
}
