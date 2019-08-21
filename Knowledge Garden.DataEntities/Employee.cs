using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Knowledge_Garden.DataEntities
{
    public class Employee
    {
        /// <summary>
        /// AspNet user id
        /// </summary>
        [Index(IsUnique = true)]
        [Required]
        public virtual ApplicationUser ApplicationUser { get; set; }

        /// <summary>
        /// Refers to the username of the application user which should map to Username
        /// in the authentication table
        /// </summary>
        [Key]
        public string Username { get; set; }

        public DateTime? LastContributionTime { get; set; }

        public virtual ICollection<Flower> Flowers { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
