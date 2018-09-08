using System.ComponentModel.DataAnnotations;
using Todo.Domain.Infrastructure;

namespace Todo.Domain.Entities
{
    public class TodoItem : BaseEntity
    {
        [StringLength(250)]
        public string Title { get; set; }

        public bool IsCompleted { get; set; }

        public int TodoListId { get; set; }


        // Relations

        public virtual TodoList TodoList { get; set; }
    }
}
