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
        /// <summary>
        /// AspNet user id
        /// </summary>
        [Index(IsUnique = true)]
        public ApplicationUser UserId { get; set; }

        /// <summary>
        /// Refers to the username of the application user which is not mapped in the
        /// database for redundance as is already exists in the authentication table
        /// </summary>
        [Index(IsUnique = true)]
        [NotMapped]
        public string Username { get; set; }

        public IEnumerable<Flower> OwnedFlowers { get; set; }

        public IEnumerable<Flower> UnreadFlowers { get; set; }

        public DateTime? LastContributionTime { get; set; }
    }
}
