using System.Collections.Generic;
using Todo.Common.Dto;

namespace Todo.Core.Repositories.RepositoryInterfaces
{
    public interface ITodoListRepository
    {
        IEnumerable<DtoTodoList> GetLists(int userId);
        void Save(DtoTodoList dto);
        void Delete(int Id);
    }
}
