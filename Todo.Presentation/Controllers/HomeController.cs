using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Todo.Common.Dto;
using Todo.WebApi.Infrastructure;

namespace Todo.Presentation.Controllers
{
    public class HomeController : TodoController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetTodoLists()
        {
            var todoLists = (IEnumerable<DtoTodoList>)ApiRequester.Call<IEnumerable<DtoTodoList>>(string.Format("todoapi/gettodolists?userId={0}", CurrentUser.Id), "GET", null).Data;

            return PartialView("_TodoLists", todoLists);
        }

        [HttpGet]
        public ActionResult GetTodoItems(int todoListId)
        {
            var todoItems = (IEnumerable<DtoTodoItem>)ApiRequester.Call<IEnumerable<DtoTodoItem>>(string.Format("todoapi/gettodoitems?todoListId={0}", todoListId), "GET", null).Data;

            return PartialView("_TodoItems", todoItems);
        }

        [HttpPost]
        public ActionResult AddTodoList(string title)
        {
            var dto = new DtoTodoList { Title = title, UserId = CurrentUser.Id };

            ApiRequester.Call<Type>("todoapi/savetodolist", "POST", dto);

            return Json(Common.Types.Response.Success());
        }

        [HttpPost]
        public ActionResult AddToDoItem(string title, int todoListId)
        {
            var dto = new DtoTodoItem { Title = title, ListId = todoListId };

            ApiRequester.Call<Type>("todoapi/savetodoitem", "POST", dto);

            return Json(Common.Types.Response.Success());
        }

        [HttpPost]
        public ActionResult ToggleTodoItemStatus(int todoItemId)
        {
            ApiRequester.Call<Type>("todoapi/toggletodoitemstatus?todoItemId=" + todoItemId, "POST", null);

            return Json(Common.Types.Response.Success());
        }
    }
}