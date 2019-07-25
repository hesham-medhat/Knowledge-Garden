using Knowledge_Garden.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knowledge_Garden.Engine.Models
{
    public class Employee
    {
        [Index(IsUnique = true)]
        public ApplicationUser UserId { get; set; }

        [Index(IsUnique = true)]
        public string Username { get; set; }

        public IEnumerable<Flower> OwnedFlowers { get; set; }

        public IEnumerable<Flower> UnreadFlowers { get; set; }

        public DateTime? LastContributionTime { get; set; }
    }
}
