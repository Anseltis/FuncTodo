using System;
using System.Drawing;

namespace ESystems.FuncTodo.Server.Host.Models
{
    public class TodoDataTransfer
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public DateTime? Deadline { get; set; }
        public int? CategoryId { get; set; }
        public bool Checked { get; set; }
        public int Order { get; set; }

    }
}
