namespace Todo.Domain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Todo.Common.Helpers;
    using Todo.Domain.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<Todo.Domain.Infrastructure.TodoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Todo.Domain.Infrastructure.TodoContext context)
        {
            context.User.AddOrUpdate(u => u.EMailAddress, new User
            {
                EMailAddress = "user@site.com",
                FullName = "Test Kullanıcısı",
                PasswordHash = Hasher.CreateHash("123456"),
                InsertDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                IsDeleted = false
            });
        }
    }
}
