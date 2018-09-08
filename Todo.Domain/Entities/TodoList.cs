using System.ComponentModel.DataAnnotations;
using Todo.Domain.Infrastructure;
using System.Collections.Generic;

namespace Todo.Domain.Entities
{
    public class TodoList : BaseEntity
    {
        [StringLength(100)]
        public string Title { get; set; }

        public int UserId { get; set; }


        // Relations

        public virtual User User { get; set; }

        public virtual ICollection<TodoItem> Items { get; set; } 
    }
}
