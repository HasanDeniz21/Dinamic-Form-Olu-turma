namespace DynamicForm.Data.Entity.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using DynamicForm.Framework.Data.Repository.EFRepositoryBase;

    public partial class DynamicFormDataContext : BaseDataContext
    {
        public DynamicFormDataContext()
            : base("name=DynamicFormDataContext")
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Form> Form { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasMany(e => e.Form)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);
        }
    }
}
