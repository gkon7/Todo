using System.Collections.Generic;
using Todo.Common.Dto;

namespace Todo.Core.Repositories.RepositoryInterfaces
{
    public interface ITodoItemRepository
    {
        IEnumerable<DtoTodoItem> GetTodoItems(int listId);
        void Save(DtoTodoItem dto);
        void ToggleStatus(int Id);
        void Delete(int Id);
    }
}
