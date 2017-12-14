using System;

namespace ESystems.FuncTodo.Infrastructure.DataAccess
{
    public interface IContextFactory<out T> where T : IDisposable
    {
        T CreateContext();
    }
}
