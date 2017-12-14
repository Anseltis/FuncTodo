using System;
using ESystems.FuncTodo.Server.DataAccess.Model.Builder;

namespace ESystems.FuncTodo.Server.DataAccess.Model.Value
{
    public sealed class TodoValue
    {
        public string Title { get; }
        public string Desc { get; }
        public DateTime? Deadline { get; }
        public int? CategoryId { get; }
        public bool Checked { get; }
        public int Order { get; }

        public TodoValue(TodoBuilder builder)
        {
            Title = builder.Title;
            Desc = builder.Desc;
            Deadline = builder.Deadline;
            CategoryId = builder.CategoryId;
            Checked = builder.Checked;
            Order = builder.Order;
        }
    }
}
