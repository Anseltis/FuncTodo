using System;

namespace ESystems.FuncTodo.Server.DataAccess.Model.Builder
{
    public class TodoBuilder
    {
        public string Title { get; set; }
        public string Desc { get; set; }
        public DateTime? Deadline { get; set; }
        public int? CategoryId { get; set; }
        public bool Checked { get; set; }
        public int Order { get; set; }
    }
}
