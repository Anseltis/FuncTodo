using ESystems.FuncTodo.Server.DataAccess.Model.Builder;

namespace ESystems.FuncTodo.Server.DataAccess.Model.Value
{
    public sealed class CategoryValue
    {
        public string Name { get; }
        public int? Color { get; }
        public int Order { get; }

        public CategoryValue(CategoryBuilder builder)
        {
            Name = builder.Name;
            Color = builder.Color;
            Order = builder.Order;
        }
    }
}
