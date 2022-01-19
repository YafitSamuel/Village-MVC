using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Village_MVC.Models
{
    public partial class VilageContext : DbContext
    {
        public VilageContext()
            : base("name=VilageContext")
        {
        }
        public virtual DbSet<Resident> Resident { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
