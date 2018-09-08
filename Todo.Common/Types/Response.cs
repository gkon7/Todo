using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Common.Types
{
    public sealed class Response
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public bool IsSucceeded
        {
            get
            {
                if (this.Status == "Success")
                {
                    return true;
                }

                return false;
            }
        }

        public static Response Error(string message = "", object data = null)
        {
            return new Response
            {
                Message = message,
                Status = "Error",
                Data = data
            };
        }

        public static Response Success(string message = "", object data = null)
        {
            return new Response
            {
                Message = message,
                Status = "Success",
                Data = data
            };
        }
    }
}
