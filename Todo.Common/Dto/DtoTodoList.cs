using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Common.Dto
{
    public class DtoTodoList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public int UncompletedTodoItemCount { get; set; }
    }
}
