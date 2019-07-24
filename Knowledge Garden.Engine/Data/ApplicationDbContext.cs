using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Knowledge_Garden.Models;
using Knowledge_Garden.Engine.Models;

namespace Knowledge_Garden.Engine.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //public DbSet<Flower> Flowers { get; set; }
        //public DbSet<Employee> Employees { get; set; }
        //public DbSet<Attachment> Attachments { get; set; }
    }
}
