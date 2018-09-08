using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Infrastructure;

namespace Todo.Core.Infrastructure
{
    public class UnitOfWork
    {
        public static TodoContext CurrentSession
        {
            get
            {
                var container = RepositoryIoc.Container;

                return container.Resolve<TodoContext>();
            }
        }
    }
}
