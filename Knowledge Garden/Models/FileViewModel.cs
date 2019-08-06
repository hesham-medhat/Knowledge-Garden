using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Knowledge_Garden.Models
{
    public class FileViewModel
    {
        [System.ComponentModel.DataAnnotations.Key]
        public HttpPostedFileBase FileBase;
    }
}
