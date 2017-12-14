namespace ESystems.FuncTodo.Infrastructure.DataAccess
{
    public sealed class Record<T>
    {
        public int Key { get; }
        public T Value { get; }

        public Record(int key, T value)
        {
            Key = key;
            Value = value;
        }
    }
}
