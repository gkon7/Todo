using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Todo.Presentation.Infrastructure;

namespace Todo.WebApi.Infrastructure
{
    public class TodoController : Controller
    {
        public TodoUser CurrentUser
        {
            get
            {
                return new TodoUser(this.User as ClaimsPrincipal);
            }
        }
    }
}