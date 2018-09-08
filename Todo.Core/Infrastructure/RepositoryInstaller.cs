using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Todo.Core.Repositories;
using Todo.Core.Repositories.RepositoryInterfaces;
using Todo.Domain.Infrastructure;

namespace Todo.Core.Infrastructure
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var dbRegistration = Component.For<TodoContext>()
                .LifeStyle
                .PerWebRequest
                .UsingFactoryMethod(p => new TodoContext())
                .LifeStyle
                .Singleton;
            container.Register(dbRegistration);

            container.Register(Component.For<IUserRepository>().ImplementedBy<UserRepository>());
        }

        private static void Register<TInterface, TRepository>(IWindsorContainer container)
            where TInterface : class
            where TRepository : TInterface
        {
            container.Register(Component.For<TInterface>()
                .ImplementedBy<TRepository>()
                .LifestyleTransient());
        }
    }
}
