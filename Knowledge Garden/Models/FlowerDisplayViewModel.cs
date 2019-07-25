using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Knowledge_Garden.Models
{
    public class FlowerDisplayViewModel
    {
        public string Title { get; set; }

        public string Problem { get; set; }

        public string Solution { get; set; }

        public string[] AttachmentNames { get; set; }

        public byte[] AttachmentBlobValues { get; set; }
    }
}