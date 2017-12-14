using System;
using ESystems.FuncTodo.Infrastructure.DataAccess;
using ESystems.FuncTodo.Server.DataAccess.Model.Builder;
using ESystems.FuncTodo.Server.DataAccess.Model.Value;

namespace ESystems.FuncTodo.Server.DataAccess.Model.Entity
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public DateTime? Deadline { get; set; }
        public int? CategoryId { get; set; }
        public bool Checked { get; set; }
        public int Order { get; set; }

        public virtual Category Category { get; set; }

        public TodoValue Value => new TodoValue(new TodoBuilder
        {
            CategoryId = CategoryId,
            Title = Title,
            Desc = Desc,
            Order = Order,
            Checked = Checked,
            Deadline = Deadline
        });

        public Record<TodoValue> Record => new Record<TodoValue>(Id, Value);

        public Todo(Record<TodoValue> record)
        {
            Id = record.Key;
            Title = record.Value.Title;
            Desc = record.Value.Desc;
            Deadline = record.Value.Deadline;
            CategoryId = record.Value.CategoryId;
            Checked = record.Value.Checked;
            Order = record.Value.Order;
        }

        public Todo(TodoValue value) : this(new Record<TodoValue>(default(int), value))
        {
        }

        public Todo()
        {
        }
    }
}
