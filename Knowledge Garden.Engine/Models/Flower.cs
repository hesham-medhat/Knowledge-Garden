using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowledge_Garden.Engine.Models
{
    public class Flower
    {
        [Key]
        public int Id { get; set; }

        public virtual Employee Owner { get; set; }

        public string OwnerUsername { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1000)]
        [Column("Problem", TypeName = "ntext")]
        public string Problem { get; set; }

        [Column("Solution", TypeName = "ntext")]
        public string Solution { get; set; }

        public DateTime LastUpdateDate { get; set; }

        public virtual ICollection<Attachment> Attachments { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
