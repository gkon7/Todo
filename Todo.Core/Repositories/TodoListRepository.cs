using System.Collections.Generic;
using System.Linq;
using Todo.Common.Dto;
using Todo.Core.Repositories.RepositoryInterfaces;
using Todo.Domain.Entities;

namespace Todo.Core.Repositories
{
    public class TodoListRepository : GenericRepository<TodoList>, ITodoListRepository
    {
        private TodoItemRepository _todoItemRepository = new TodoItemRepository();

        public IEnumerable<DtoTodoList> GetLists(int userId)
        {
            return GetAll(l => l.UserId == userId).ToList().Select(s => new DtoTodoList
            {
                Id = s.Id,
                Title = s.Title,
                UserId = s.UserId,
                UncompletedTodoItemCount = _todoItemRepository.GetAll(t=>t.TodoListId == s.Id && !t.IsCompleted).Count()
            });
        }

        public void Save(DtoTodoList dto)
        {
            if (dto.Id > 0)
            {
                var entity = Get(dto.Id);

                entity.Title = dto.Title;
            }

            else
            {
                Add(new TodoList
                {
                    Title = dto.Title,
                    UserId = dto.UserId
                });
            }

            Commit();
        }

        public void Delete(int Id)
        {
            var entity = Get(Id);

            Delete(entity);

            Commit();
        }
    }
}
