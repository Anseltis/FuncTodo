using System.Collections.Generic;
using ESystems.FuncTodo.Infrastructure.DataAccess;
using ESystems.FuncTodo.Server.DataAccess.Model.Builder;
using ESystems.FuncTodo.Server.DataAccess.Model.Value;

namespace ESystems.FuncTodo.Server.DataAccess.Model.Entity
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Color { get; set; }
        public int Order { get; set; }

        public virtual ICollection<Todo> Todoes { get; set; }

        public CategoryValue Value => new CategoryValue(new CategoryBuilder
        {
            Name = Name,
            Color = Color,
            Order = Order
        });

        public Record<CategoryValue> Record => new Record<CategoryValue>(Id, Value);

        public Category(Record<CategoryValue> record)
        {
            Id = record.Key;
            Name = record.Value.Name;
            Color = record.Value.Color;
            Order = record.Value.Order;
        }

        public Category(CategoryValue value) : this(new Record<CategoryValue>(default(int), value))
        {
        }

        public Category()
        {
        }
    }
}
