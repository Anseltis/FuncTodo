using System.Collections.Generic;

namespace ESystems.FuncTodo.Infrastructure.DataAccess
{
    public interface IRepository<T>
    {
        Record<T> Get(int id);
        IEnumerable<Record<T>> GetAll();
        int Add(T value);
        void Delete(int id);
        void Update(Record<T> record);
    }
}
