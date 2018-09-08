using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Todo.Presentation.Infrastructure
{
    public class TodoUser : ClaimsPrincipal
    {

        public TodoUser(ClaimsPrincipal principal)
            : base(principal)
        {
        }

        public int Id
        {
            get
            {
                return this.FindFirst("Id") == null ? 0 : Convert.ToInt32(this.FindFirst("Id").Value);
            }
        }

        public string FullName
        {
            get
            {
                return this.FindFirst(ClaimTypes.Name).Value;
            }
        }

        public string EMailAddress
        {
            get
            {
                return this.FindFirst(ClaimTypes.Email).Value;
            }
        }

    }
}