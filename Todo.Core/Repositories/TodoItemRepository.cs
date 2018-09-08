using System.Collections.Generic;
using System.Linq;
using Todo.Common.Dto;
using Todo.Core.Repositories.RepositoryInterfaces;
using Todo.Domain.Entities;

namespace Todo.Core.Repositories
{
    public class TodoItemRepository : GenericRepository<TodoItem>, ITodoItemRepository
    {
        public IEnumerable<DtoTodoItem> GetTodoItems(int listId)
        {
            return GetAll(t => t.TodoListId == listId).Select(s => new DtoTodoItem
            {
                Id = s.Id,
                Title = s.Title,
                IsCompleted = s.IsCompleted,
                CreationDate = s.InsertDate
            });
        }

        public void Save(DtoTodoItem dto)
        {
            if (dto.Id > 0)
            {
                var entity = Get(dto.Id);

                entity.Title = dto.Title;
            }

            else
            {
                Add(new TodoItem
                {
                    Title = dto.Title,
                    TodoListId = dto.ListId
                });
            }

            Commit();
        }

        public void ToggleStatus(int Id)
        {
            var entity = Get(Id);

            entity.IsCompleted = !entity.IsCompleted;

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
