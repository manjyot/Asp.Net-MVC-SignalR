namespace ClickTickerSample
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=TestModel")
        {
        }

        public virtual DbSet<DevTest> DevTests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DevTest>()
                .Property(e => e.CampaignName)
                .IsUnicode(false);

            modelBuilder.Entity<DevTest>()
                .Property(e => e.AffiliateName)
                .IsUnicode(false);
        }
    }
}
