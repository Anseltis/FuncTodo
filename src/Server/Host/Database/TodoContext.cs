using System.IO;
using System.Reflection;
using ESystems.FuncTodo.Infrastructure.DataAccess;
using ESystems.FuncTodo.Server.DataAccess;
using ESystems.FuncTodo.Server.DataAccess.Model.Entity;
using ESystems.FuncTodo.Server.DataAccess.Model.Value;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ESystems.FuncTodo.Server.Host.Database
{
    public class TodoContext: DbContext, ITodoContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Todo> Todoes { get; set; }

        EntityEntry<Category> ITodoContext.Entry(Record<CategoryValue> record) => Entry(new Category(record));

        EntityEntry<Todo> ITodoContext.Entry(Record<TodoValue> record) => Entry(new Todo(record));

        void ITodoContext.SaveChanges() => base.SaveChanges();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().ToTable(nameof(Category));
            modelBuilder.Entity<Todo>().ToTable(nameof(Todo));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            optionsBuilder.UseSqlite($"Data Source={Path.Combine(path, "Database/todo.db")}");
        }
    }
}
