using Autofac;
using Autofac.Extras.DynamicProxy;
using AutoMapper;

using ESystems.FuncTodo.Infrastructure.DataAccess;
using ESystems.FuncTodo.Server.DataAccess;
using ESystems.FuncTodo.Server.DataAccess.Model.Value;
using ESystems.FuncTodo.Server.DataAccess.Repository;
using ESystems.FuncTodo.Server.Host.Database;
using ESystems.FuncTodo.Server.Host.Infrastructure;

namespace ESystems.FuncTodo.Server.Host.Resolving
{
    public static class ContainerExtension
    {
        public static ContainerBuilder UseTodo(this ContainerBuilder builder)
        {
            builder.RegisterType<CallLogger>();
            builder.RegisterType<TodoContextFactory>().As<IContextFactory<ITodoContext>>();
            builder.RegisterType<TodoContext>().As<ITodoContext>()
                .EnableInterfaceInterceptors().InterceptedBy(typeof(CallLogger));

            builder.RegisterType<CategoryRepository>().As<IOrderedRepository<CategoryValue>>();
            builder.RegisterType<TodoRepository>().As<IOrderedRepository<TodoValue>>();

            var mapper = new MapperConfiguration(congig =>
                {
                    congig.UseTodo();
                })
                .CreateMapper();
            builder.RegisterInstance(mapper).As<IMapper>();

            return builder;
        }
    }
}
