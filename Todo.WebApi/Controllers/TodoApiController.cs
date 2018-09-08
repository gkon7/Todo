using System.Collections.Generic;
using System.Web.Http;
using Todo.Common.Dto;
using Todo.Common.Types;
using Todo.Core.Repositories.RepositoryInterfaces;

namespace Todo.WebApi.Controllers
{
    public class TodoApiController : ApiController
    {
        private ITodoListRepository _todoListRepository;
        private ITodoItemRepository _todoItemRepository;

        public TodoApiController(ITodoListRepository todoListRepository, ITodoItemRepository todoItemRepository)
        {
            _todoListRepository = todoListRepository;
            _todoItemRepository = todoItemRepository;
        }

        [HttpGet]
        public IEnumerable<DtoTodoList> GetTodoLists(int userId)
        {
            return _todoListRepository.GetLists(userId);
        }

        [HttpGet]
        public IEnumerable<DtoTodoItem> GetTodoItems(int todoListId)
        {
            return _todoItemRepository.GetTodoItems(todoListId);
        }

        [HttpPost]
        public void SaveTodoList(DtoTodoList dto)
        {
            _todoListRepository.Save(dto);
        }

        [HttpPost]
        public void SaveTodoItem(DtoTodoItem dto)
        {
            _todoItemRepository.Save(dto);
        }

        [HttpPost]
        public void ToggleTodoItemStatus(int todoItemId)
        {
            _todoItemRepository.ToggleStatus(todoItemId);
        }
    }
}