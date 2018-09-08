namespace Todo.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TodoItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 250),
                        IsCompleted = c.Boolean(nullable: false),
                        TodoListId = c.Int(nullable: false),
                        InsertDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TodoList", t => t.TodoListId)
                .Index(t => t.TodoListId);
            
            CreateTable(
                "dbo.TodoList",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                        UserId = c.Int(nullable: false),
                        InsertDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(maxLength: 100),
                        EMailAddress = c.String(maxLength: 250),
                        PasswordHash = c.String(maxLength: 250),
                        InsertDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TodoList", "UserId", "dbo.User");
            DropForeignKey("dbo.TodoItem", "TodoListId", "dbo.TodoList");
            DropIndex("dbo.TodoList", new[] { "UserId" });
            DropIndex("dbo.TodoItem", new[] { "TodoListId" });
            DropTable("dbo.User");
            DropTable("dbo.TodoList");
            DropTable("dbo.TodoItem");
        }
    }
}
