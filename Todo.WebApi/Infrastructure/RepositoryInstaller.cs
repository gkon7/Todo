using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Todo.Core.Repositories;
using Todo.Core.Repositories.RepositoryInterfaces;

namespace Todo.WebApi.Infrastructure
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IUserRepository>().ImplementedBy<UserRepository>());
            container.Register(Component.For<ITodoListRepository>().ImplementedBy<TodoListRepository>());
            container.Register(Component.For<ITodoItemRepository>().ImplementedBy<TodoItemRepository>());
        }
    }
}