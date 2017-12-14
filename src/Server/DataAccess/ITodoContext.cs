using System;
using ESystems.FuncTodo.Infrastructure.DataAccess;
using ESystems.FuncTodo.Server.DataAccess.Model.Entity;
using ESystems.FuncTodo.Server.DataAccess.Model.Value;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace ESystems.FuncTodo.Server.DataAccess
{
    /// <summary>
    /// Interface of universal context 
    /// </summary>
    public interface ITodoContext : IDisposable
    {
        /// <summary>
        /// Gets or sets values of category repository
        /// </summary>
        DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Gets or sets values of todoo repository
        /// </summary>
        DbSet<Todo> Todoes { get; set; }

        /// <summary>
        /// Attaches a record into category repository
        /// </summary>
        /// <param name="record">Record</param>
        /// <returns>An attached entity</returns>
        EntityEntry<Category> Entry(Record<CategoryValue> record);

        /// <summary>
        /// Attaches a record into todoo repository
        /// </summary>
        /// <param name="record">Record</param>
        /// <returns>An attached entity</returns>
        EntityEntry<Todo> Entry(Record<TodoValue> record);

        /// <summary>
        /// Saves all confirmed changes
        /// </summary>
        void SaveChanges();
    }
}