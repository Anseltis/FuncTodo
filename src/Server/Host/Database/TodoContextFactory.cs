using Autofac;
using ESystems.FuncTodo.Infrastructure.DataAccess;
using ESystems.FuncTodo.Server.DataAccess;

namespace ESystems.FuncTodo.Server.Host.Database
{
    public sealed class TodoContextFactory : IContextFactory<ITodoContext>
    {
        private readonly IComponentContext _context;
        public TodoContextFactory(IComponentContext context) => _context = context;
        public ITodoContext CreateContext() => _context.Resolve<ITodoContext>();
    }
}
