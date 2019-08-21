using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowledge_Garden.DataEntities.Models
{
    public class FlowerBL
    {
        [Key]
        public int Id { get; set; }

        public string OwnerUsername { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Problem { get; set; }

        public string Solution { get; set; }

        public DateTime LastUpdateDate { get; set; }
    }
}
