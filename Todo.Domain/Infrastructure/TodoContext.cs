using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entities;

namespace Todo.Domain.Infrastructure
{
    public class TodoContext : DbContext
    {
        public TodoContext() : base("TodoConnectionString")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            Database.SetInitializer<TodoContext>(null);

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            InsertListener();
            UpdateListener();
            DeleteListener();

            return base.SaveChanges();
        }

        private void InsertListener()
        {
            foreach (var entity in ChangeTracker.Entries<BaseEntity>().Where(x => x.State == EntityState.Added).ToList())
            {
                entity.Entity.InsertDate = DateTime.Now;
                entity.Entity.UpdateDate = DateTime.Now;
                entity.Entity.IsDeleted = false;
            }
        }

        private void UpdateListener()
        {
            foreach (var entity in ChangeTracker.Entries<BaseEntity>().Where(x => x.State == EntityState.Modified).ToList())
            {
                entity.Entity.UpdateDate = DateTime.Now;
                entity.Entity.IsDeleted = false;
            }
        }

        private void DeleteListener()
        {
            foreach (var entity in ChangeTracker.Entries<BaseEntity>().Where(x => x.State == EntityState.Deleted).ToList())
            {
                entity.Entity.IsDeleted = true;
                entity.Entity.UpdateDate = DateTime.Now;
                entity.State = EntityState.Modified;
            }
        }

        public DbSet<User> User { get; set; }
        public DbSet<TodoList> TodoList { get; set; }
        public DbSet<TodoItem> TodoItem { get; set; }
    }
}
