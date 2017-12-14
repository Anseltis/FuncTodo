using System;
using System.Collections.Generic;
using System.Linq;
using ESystems.FuncTodo.Infrastructure.DataAccess;
using ESystems.FuncTodo.Server.DataAccess.Model.Entity;
using ESystems.FuncTodo.Server.DataAccess.Model.Value;
using Microsoft.EntityFrameworkCore;

namespace ESystems.FuncTodo.Server.DataAccess.Repository
{
    public class TodoRepository: IOrderedRepository<TodoValue>
    {
        private readonly IContextFactory<ITodoContext> _contextFactory;

        public TodoRepository(IContextFactory<ITodoContext> contextFactory)
        {
            _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
        }

        public int Add(TodoValue value)
        {
            var entity = new Todo(value);
            using (var context = _contextFactory.CreateContext())
            {
                try
                {
                    context.Todoes.Add(entity);
                    context.SaveChanges();
                }
                catch
                {
                    //throw new DataValidationException();
                }

                return entity.Id;
            }
        }

        public void Delete(int id)
        {
            using (var context = _contextFactory.CreateContext())
            {
                foreach (var entity in context.Todoes.Where(record => record.Id == id))
                {
                    context.Todoes.Remove(entity);
                }
                context.SaveChanges();
            }
        }

        public Record<TodoValue> Get(int id)
        {
            using (var context = _contextFactory.CreateContext())
            {
                return context.Todoes.Where(c => c.Id == id)
                    .Take(1)
                    .ToList()
                    .Select(todo => todo.Record)
                    .FirstOrDefault();
            }
        }

        public IEnumerable<Record<TodoValue>> GetAll()
        {
            using (var context = _contextFactory.CreateContext())
            {
                return context.Todoes
                    .AsEnumerable()
                    .Select(todo => todo.Record)
                    .ToList();
            }
        }

        public void Update(Record<TodoValue> record)
        {
            using (var context = _contextFactory.CreateContext())
            {
                try
                {
                    var entry = context.Entry(record);
                    entry.State = EntityState.Modified;
                    context.SaveChanges();
                }
                catch
                {
                    //throw new DataValidationException();
                }
            }
        }

        public Record<TodoValue> GetLast()
        {
            using (var context = _contextFactory.CreateContext())
            {
                return context.Todoes
                    .OrderByDescending(todo => todo.Id)
                    .Take(1)
                    .ToList()
                    .Select(todo => todo.Record)
                    .FirstOrDefault();
            }
        }
    }
}
