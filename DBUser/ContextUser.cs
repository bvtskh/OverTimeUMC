namespace OverTime
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ContextUser : DbContext
    {
        public ContextUser()
            : base("data source=172.28.10.22;initial catalog=PI_BASE;persist security info=True;user id=lca;password=umc@123;MultipleActiveResultSets=True;App=EntityFramework")
        {
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WorkOrder> WorkOrders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<WorkOrder>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<WorkOrder>()
                .Property(e => e.OrderNo)
                .IsUnicode(false);
        }
    }
}
