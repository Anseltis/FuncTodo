using System.Drawing;

namespace ESystems.FuncTodo.Server.Host.Models
{
    public class CategoryDataTransfer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public Color? Color { get; set; }

    }
}
