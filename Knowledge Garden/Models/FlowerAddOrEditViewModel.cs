using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Knowledge_Garden.Models
{
    public class FlowerAddOrEditViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Problem { get; set; }
        
        public string Solution { get; set; }

        public string[] AttachmentNames { get; set; }

        public byte[] AttachmentBlobValues { get; set; }
    }
}
