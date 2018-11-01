namespace Nteir.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class nteirContext : DbContext
    {
        public nteirContext()
            : base("name=nteirConStr")
        {
        }

        public virtual DbSet<Kullanici> Kullanici { get; set; }
        public virtual DbSet<Rehber> Rehber { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
