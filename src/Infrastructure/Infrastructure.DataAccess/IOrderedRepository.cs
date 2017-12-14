namespace ESystems.FuncTodo.Infrastructure.DataAccess
{
    public interface IOrderedRepository<T> : IRepository<T>
    {
        Record<T> GetLast();
    }
}
