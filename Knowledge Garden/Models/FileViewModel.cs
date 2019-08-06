using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Knowledge_Garden.Models
{
    public class FileViewModel
    {
        [Required]
        public HttpPostedFileBase FileBase;
    }
}
